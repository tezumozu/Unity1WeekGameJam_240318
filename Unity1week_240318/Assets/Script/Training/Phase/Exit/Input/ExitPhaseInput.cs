using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class ExitPhaseInput : MonoBehaviour{

    [Inject]
    TrainingGameManager gameManager;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip clickSE;

    private string inputedName;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

    private bool isWaitClick;

    private Subject<Unit> clickSubject = new Subject<Unit>();
    public IObservable<Unit> ClickAsync => clickSubject;

    private Subject<Unit> escSubject = new Subject<Unit>();
    public IObservable<Unit> escAsync => escSubject;


    private void Start() {
        gameManager.GameStateAsync
        .Subscribe((x)=>{
            if(x == E_TrainingState.Exit){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);

        //ポーズを監視
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            if(flag){
                isActiveForCurrentState = false;
            }else{
                isActiveForCurrentState = true;
                isChangeMode = true;
            }
        })
        .AddTo(this);
    }


    // Update is called once per frame
    void Update(){
        //もし　ゲームの状態がEnterでない または　モードが切り替わったタイミング　ならリターン
        if(!isActiveForCurrentState || isChangeMode ) {
            isChangeMode = false;
            return;
        }

        if(Input.GetMouseButtonDown(1)){
            escSubject.OnNext(Unit.Default);

        }else if(Input.GetMouseButtonDown(0)){
            isWaitClick = true;
        }
    }


    public IEnumerator WaitClickInput(){
        isWaitClick = false;

        while(!isWaitClick){
            yield return isWaitClick;
        }

        //効果音を鳴らす;
        soundPlayer.PlaySE(clickSE);

        yield return isWaitClick;
    }
}
