using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using My1WeekGameSystems_ver2;

public class EvoGameManager : I_SceneLoadAlertable,IDisposable{

    private Subject<E_SceneName> SceneLoadSubject;
    public IObservable<E_SceneName> SceneLoadAscnc => SceneLoadSubject;

    private Subject<bool> PauseSubject;
    public IObservable<bool> PauseAsync => PauseSubject;

    private Subject<E_EvoState> GameStateSubject;
    public IObservable<E_EvoState> GameStateAsync => GameStateSubject;

    private Dictionary<E_EvoState,TrainingPhase> phaseManager;

    private List<IDisposable> DisposeList;

    private IEnumerator currentCoroutine;

    public EvoGameManager(){
        DisposeList = new List<IDisposable>();
        SceneLoadSubject = new Subject<E_SceneName>();
        PauseSubject = new Subject<bool>();
        GameStateSubject = new Subject<E_EvoState>();

        phaseManager = new Dictionary<E_EvoState,TrainingPhase>();
        phaseManager[E_EvoState.Evo] = new EvoPhaseManager();
        phaseManager[E_EvoState.Result] = new EvoResultPhaseManager();


        //フェーズの終了を監視
        var disposable = phaseManager[E_EvoState.Evo].StateFinishAsync
        .Subscribe((_)=>{
            GameStateSubject.OnNext(E_EvoState.Result);
            currentCoroutine = phaseManager[E_EvoState.Result].StartPhase();
            CoroutineHander.OrderStartCoroutine(currentCoroutine);
        });

        DisposeList.Add(disposable);


        //フェーズの終了を監視
        disposable = phaseManager[E_EvoState.Result].StateFinishAsync
        .Subscribe((_)=>{
            SceneLoadSubject.OnNext(E_SceneName.BattleScene);
        });

        DisposeList.Add(disposable);


        //ポーズの入力を監視
        var EvoInput = GameObject.Find("EvoInputManager").GetComponent<EvoInputManager>();

        disposable = EvoInput.escAsync.Subscribe((_)=>{
            CoroutineHander.OrderStopCoroutine(currentCoroutine);
            PauseSubject.OnNext(true);
        });

        DisposeList.Add(disposable);


        //ポーズの入力を監視
        var pauseInput = GameObject.Find("PauseInputManager").GetComponent<EvoPauseInputManager>();

        disposable = pauseInput.escAsync.Subscribe((_)=>{
            CoroutineHander.ReStartCoroutine(currentCoroutine);
            PauseSubject.OnNext(false);
        });

        DisposeList.Add(disposable);


        //タイトル画面への遷移を監視
        var pause = GameObject.Find("Canvas/PauseUI").GetComponent<EvoPauseUIManager>();

        disposable = pause.BackToTitleAsync.Subscribe((_)=>{
            CoroutineHander.StopAllActiveCoroutine();
            SceneLoadSubject.OnNext(E_SceneName.BattleScene);
        });

        DisposeList.Add(disposable);


    }


    public IDisposable ObserveSceneLoadAlert(Action<E_SceneName> action){
        return SceneLoadSubject.Subscribe((type) => {
            action(type);
        });
    }


    public void StartGame(){
        GameStateSubject.OnNext(E_EvoState.Evo);
        currentCoroutine = phaseManager[E_EvoState.Evo].StartPhase();
        CoroutineHander.OrderStartCoroutine(currentCoroutine);
    }


    public void Dispose(){
        foreach (var item in DisposeList){
            item.Dispose();
        }

        foreach(var manager in phaseManager.Values){
            manager.Dispose();
        }
    }
}
