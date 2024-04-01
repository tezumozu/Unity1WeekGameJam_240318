using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PauseInputManager : MonoBehaviour{

    private Subject<Unit> clickSubject = new Subject<Unit>();
    private Subject<Unit> escSubject = new Subject<Unit>();
    private Subject<E_OptionType> OptionUISubject = new Subject<E_OptionType>();

    public IObservable<Unit> clickAsync => clickSubject;
    public IObservable<Unit> escAsync => escSubject;
    public IObservable<E_OptionType> OptionUIAsync => OptionUISubject;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

    private void Start() {
        BattleSceneManager.currentStateAsync
        .Subscribe((x)=>{
            if(x == E_BattleSceneState.Pause){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);

    }

    // Update is called once per frame
    void Update(){
        //もしゲームの状態がPauseでないならリターン
        if(!isActiveForCurrentState || isChangeMode ) {
            isChangeMode = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            //効果音を鳴らす
            escSubject.OnNext(Unit.Default);

        }else if(Input.GetMouseButtonDown(0)){
            //効果音を鳴らす
            clickSubject.OnNext(Unit.Default);
        }


    }
}
