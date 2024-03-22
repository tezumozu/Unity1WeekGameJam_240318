using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleInputManager : MonoBehaviour{

    private Subject<Unit> clickSubject = new Subject<Unit>();
    private Subject<Unit> escSubject = new Subject<Unit>();
    private Subject<E_ActionType> ActionUISubject = new Subject<E_ActionType>();

    public IObservable<Unit> clickAsync => clickSubject;
    public IObservable<Unit> escAsync => escSubject;
    public IObservable<E_ActionType> ActionUIAsync => ActionUISubject;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

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
        .Subscribe((type)=>{
            ActionUISubject.OnNext(type);
        })
        .AddTo(this);

        //防御
        battleMenu.DefenseButton.PushButtonAsync
        .Subscribe((type)=>{
            ActionUISubject.OnNext(type);
        })
        .AddTo(this);


        //動的生成しているボタンUIの更新を監視/更新
        skillListMenu.UpdateUIAsync
        .Subscribe((skillList)=>{
            foreach (var item in skillList){

                item.PushButtonAsync
                .Subscribe((type)=>{
                    ActionUISubject.OnNext(type);
                })
                .AddTo(this);

            }
        })
        .AddTo(this);
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
            clickSubject.OnNext(Unit.Default);
        }


    }
}
