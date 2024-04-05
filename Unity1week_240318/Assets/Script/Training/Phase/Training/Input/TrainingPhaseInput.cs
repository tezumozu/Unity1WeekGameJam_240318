using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class TrainingPhaseInput : MonoBehaviour{

    [Inject]
    TrainingGameManager gameManager;

    [SerializeField]
    TrainingUIManager UIManager;


    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;


    private Subject<Unit> escSubject = new Subject<Unit>();
    public IObservable<Unit> escAsync => escSubject;


    private Subject<E_TrainingType> PushButtonSubject = new Subject<E_TrainingType>();
    public IObservable<E_TrainingType> PushButtonAsync => PushButtonSubject;



    private bool isWaitClick;

    private Subject<Unit> clickSubject = new Subject<Unit>();
    public IObservable<Unit> ClickAsync => clickSubject;



    private void Start() {

        gameManager.GameStateAsync
        .Subscribe((x)=>{
            if(x == E_TrainingState.Training){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);

        UIManager.PushButtonAsync
        .Subscribe((type) => {
            PushButtonSubject.OnNext(type);
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
            yield return null;
        }

        //効果音を鳴らす;
    }

}
