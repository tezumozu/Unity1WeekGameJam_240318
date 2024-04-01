using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleInputManager : MonoBehaviour{

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    private Subject<Unit> escSubject = new Subject<Unit>();

    public IObservable<Unit> escAsync => escSubject;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

    private E_ActionType inputActionType;
    private bool isWaitPushButton;
    private bool isWaitClick;

    private void Start() {
        BattleSceneManager.currentStateAsync
        .Subscribe((x)=>{
            if(x == E_BattleSceneState.Battle){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);


        //ボタンUIを監視
        var battleMenu = GameObject.Find("Canvas/BattleUI").GetComponent<BattleMenuManager>();
        var skillListMenu = GameObject.Find("Canvas/BattleUI").GetComponent<SkillListManager>();

        //攻撃
        battleMenu.AttackButton.PushButtonAsync
        .Where(_ => isWaitPushButton)
        .Subscribe((type)=>{
            isWaitPushButton = false;
            inputActionType = type;
        })
        .AddTo(this);

        //防御
        battleMenu.DefenseButton.PushButtonAsync
        .Where(_ => isWaitPushButton)
        .Subscribe( (type) => {
            isWaitPushButton = false;
            inputActionType = type;
        })
        .AddTo(this);


        //動的生成しているボタンUIの更新を監視/更新
        skillListMenu.UpdateUIAsync
        .Subscribe((skillList)=>{
            foreach (var item in skillList){

                item.PushButtonAsync
                .Where(_ => isWaitPushButton)
                .Subscribe((type)=>{
                    isWaitPushButton = false;
                    inputActionType = type;
                })
                .AddTo(this);

            }
        })
        .AddTo(this);


        isWaitPushButton = false;
        isWaitClick = false;
    }


    // Update is called once per frame
    void Update(){
        //もしゲームの状態がBattleでな または　モードが切り替わったタイミングでないならリターン
        if(!isActiveForCurrentState || isChangeMode ) {
            isChangeMode = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            escSubject.OnNext(Unit.Default);

        }else if(Input.GetMouseButtonDown(0)){
            isWaitClick = false;
        }
    }


    public IEnumerator WaitClickInput(){
        isWaitClick = true;

        while(isWaitClick){
            yield return null;
        }

        //効果音を鳴らす;
        soundPlayer.PlaySE(desitionSE);
    }

    public IEnumerator WaitPushButton(){
        isWaitPushButton = true;

        while(isWaitPushButton){
            yield return null;
        }

        //効果音を鳴らす;
        soundPlayer.PlaySE(desitionSE);

        yield return inputActionType;
    }
}
