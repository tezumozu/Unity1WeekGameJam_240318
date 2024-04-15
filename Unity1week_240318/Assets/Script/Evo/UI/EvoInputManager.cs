using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class EvoInputManager : MonoBehaviour{
    [Inject]
    EvoGameManager gameManager;

    private bool isActiveForCurrentState = true;
    private bool isChangeMode = false;


    private Subject<Unit> escSubject = new Subject<Unit>();
    public IObservable<Unit> escAsync => escSubject;


    private bool isWaitClick;

    private Subject<Unit> clickSubject = new Subject<Unit>();
    public IObservable<Unit> ClickAsync => clickSubject;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip clickSE;

    private void Start() {

        /*
        gameManager.GameStateAsync
        .Subscribe((state)=>{
            if(state == E_EvoState.Evo){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);*/


        gameManager.PauseAsync
        .Subscribe((x)=>{
            if(!x){
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
        //もし　ゲームの状態がEnterでない または　モードが切り替わったタイミング　ならリターン
        if(!isActiveForCurrentState || isChangeMode ) {
            isChangeMode = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
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
