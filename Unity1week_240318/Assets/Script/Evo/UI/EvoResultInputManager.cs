using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class EvoResultInputManager : MonoBehaviour{
   [Inject]
    EvoGameManager gameManager;

    [SerializeField]
    EvoResultUIManager UIManager;
    
    private string inputedName;

    private bool isActiveForCurrentState = false;
    private bool isChangeMode = false;

    private Subject<Unit> escSubject = new Subject<Unit>();
    public IObservable<Unit> escAsync => escSubject;

    private Subject<Unit> ToNextSceneSubject = new Subject<Unit>();
    public IObservable<Unit> ToNextSceneAsync => ToNextSceneSubject;

    private void Start() {

        gameManager.GameStateAsync
        .Subscribe((state)=>{
            if(state == E_EvoState.Result){
                isActiveForCurrentState = true;
                isChangeMode = true;
            }else{
                isActiveForCurrentState = false;
            }
        })
        .AddTo(this);

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
        UIManager.ToNextSceneAsync
        .Subscribe((_) =>{
            ToNextSceneSubject.OnNext(Unit.Default);
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
