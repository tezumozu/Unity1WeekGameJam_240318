using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class TrainingPauseInput : MonoBehaviour{

    [Inject]
    TrainingGameManager gameManager;

    [SerializeField]
    TrainingPauseUIManager UIManager;
    
    private string inputedName;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

    private bool isInputName;

    private Subject<Unit> escSubject = new Subject<Unit>();
    public IObservable<Unit> escAsync => escSubject;

    private Subject<Unit> BackToTitleSubject = new Subject<Unit>();
    public IObservable<Unit> BackToTitleAsync => BackToTitleSubject;

    private void Start() {
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            if(flag){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);

        //UIの入力を監視
        UIManager.BackToTitleAsync
        .Subscribe((_) =>{
            BackToTitleSubject.OnNext(Unit.Default);
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
        }
    }
}
