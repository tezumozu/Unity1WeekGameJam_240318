using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using My1WeekGameSystems_ver2;

public class TrainingGameManager : I_SceneLoadAlertable{

    private Subject<E_TrainingState> GameStateSubject;
    public IObservable<E_TrainingState> GameStateAsync => GameStateSubject;

    private Subject<bool> PauseSubject;
    public IObservable<bool> PauseAsync => PauseSubject;

    private Subject<E_SceneName> sceneLoadSubject;
    public IObservable<E_SceneName> sceneLoadAsync => sceneLoadSubject;

    private Dictionary< E_TrainingState , TrainingPhase > PhaseManagerDic;
    private E_TrainingState currentState;
    private IEnumerator currentStateCoroutine;

    protected List<IDisposable> DisposeList;

    public TrainingGameManager(){
        currentState = E_TrainingState.Enter;

        GameStateSubject = new Subject<E_TrainingState>();
        PauseSubject = new Subject<bool>();
        sceneLoadSubject = new Subject<E_SceneName>();

        PhaseManagerDic = new Dictionary < E_TrainingState , TrainingPhase >();
        DisposeList = new List<IDisposable>();

        //入力を取得
        var EnterInput = GameObject.Find("Inputs/EnterPhaseInput").GetComponent<EnterPhaseInput>();
        var TrainingInput = GameObject.Find("Inputs/TrainingPhaseInput").GetComponent<TrainingPhaseInput>();
        var ExitInput = GameObject.Find("Inputs/ExitPhaseInput").GetComponent<ExitPhaseInput>();
        var PauseInput = GameObject.Find("Inputs/PauseInput").GetComponent<PauseInput>();

        //escを監視
        //Enter
        var disposable = EnterInput.escAsync.Subscribe((_)=>{
            //コルーチンを止める
            CoroutineHander.OrderStopCoroutine(currentStateCoroutine);
            //ポーズ状態になったことを通知
            PauseSubject.OnNext(true);
        });

        DisposeList.Add(disposable);


        //Training
        disposable = TrainingInput.escAsync.Subscribe((_)=>{
            //コルーチンを止める
            CoroutineHander.OrderStopCoroutine(currentStateCoroutine);
            //ポーズ状態になったことを通知
            PauseSubject.OnNext(true);
        });

        DisposeList.Add(disposable);


        //Exit
        disposable = ExitInput.escAsync.Subscribe((_)=>{
            //コルーチンを止める
            CoroutineHander.OrderStopCoroutine(currentStateCoroutine);
            //ポーズ状態になったことを通知
            PauseSubject.OnNext(true);
        });

        DisposeList.Add(disposable);


        //Pause
        disposable = PauseInput.escAsync.Subscribe((_)=>{
            //ポーズ状態が解除されたことを通知
            PauseSubject.OnNext(false);
            //コルーチンを再開する
            CoroutineHander.OrderStartCoroutine(currentStateCoroutine);
        });

        DisposeList.Add(disposable);


        //タイトルへ戻るか監視
        disposable = PauseInput.escAsync.Subscribe((_)=>{
            //コルーチンを止める
            CoroutineHander.StopAllActiveCoroutine();
            //タイトルへ戻る
            sceneLoadSubject.OnNext(E_SceneName.TitleScene);
        });

        DisposeList.Add(disposable);



        //各フェーズの初期化と終了の監視
        PhaseManagerDic[E_TrainingState.Enter] = new EnterPhaseManager();
        PhaseManagerDic[E_TrainingState.Training] = new TrainingPhaseManager();
        PhaseManagerDic[E_TrainingState.Exit] = new ExitPhaseManager();


        //Enter
        disposable = PhaseManagerDic[E_TrainingState.Enter].StateFinishAsync
        .Subscribe((_)=>{
            currentState = E_TrainingState.Training;
            GameStateSubject.OnNext(currentState);
            currentStateCoroutine = PhaseManagerDic[currentState].StartPhase();
            CoroutineHander.OrderStartCoroutine(currentStateCoroutine);
        });

        DisposeList.Add(disposable);


        //Training
        disposable = PhaseManagerDic[E_TrainingState.Training].StateFinishAsync
        .Subscribe((_)=>{
            currentState = E_TrainingState.Exit;
            GameStateSubject.OnNext(currentState);
            currentStateCoroutine = PhaseManagerDic[currentState].StartPhase();
            CoroutineHander.OrderStartCoroutine(currentStateCoroutine);
        });

        DisposeList.Add(disposable);


        //Exit
        disposable = PhaseManagerDic[E_TrainingState.Exit].StateFinishAsync
        .Subscribe((_)=>{
            //コルーチンを止める　念のため
            CoroutineHander.StopAllActiveCoroutine();

            sceneLoadSubject.OnNext(E_SceneName.EvoScene);
        });


        DisposeList.Add(disposable);

        //最初のコルーチンをセット 
        currentStateCoroutine = PhaseManagerDic[E_TrainingState.Enter].StartPhase();
    }


    public void StartGame(){
        CoroutineHander.OrderStartCoroutine(currentStateCoroutine);
    }



    public IDisposable ObserveSceneLoadAlert(Action<E_SceneName> action){
        return sceneLoadSubject.Subscribe((type) => {
            action(type);
        });
    }
}
