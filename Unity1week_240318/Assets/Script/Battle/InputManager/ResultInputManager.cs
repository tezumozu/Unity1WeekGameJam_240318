using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultInputManager : MonoBehaviour{
    private Subject<Unit> clickSubject = new Subject<Unit>();
    private Subject<E_OptionType> ResultUISubject = new Subject<E_OptionType>();

    public IObservable<Unit> clickAsync => clickSubject;
    public IObservable<E_OptionType> ResultUIAsync => ResultUISubject;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

    private void Start() {
        BattleSceneManager.currentStateAsync
        .Subscribe((x)=>{
            if(x == E_BattleSceneState.Result){
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
        //もしゲームの状態がResultでないなら
        if(!isActiveForCurrentState || isChangeMode ) {
            isChangeMode = false;
            return;
        }

        if(Input.GetMouseButtonDown(0)){
            clickSubject.OnNext(Unit.Default);
        }
    }
}
