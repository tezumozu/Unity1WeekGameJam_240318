using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using My1WeekGameSystems_ver2;

public class TitleGameManager : I_SceneLoadAlertable,IDisposable{
    private Subject<E_SceneName> sceneLoadSubject;

    private static Subject<E_TitleSceneState> StateSubject = new Subject<E_TitleSceneState>();
    public static IObservable<E_TitleSceneState> StateAsync => StateSubject;

    private Subject<E_SceneName> SceneLoadSubject;
    private readonly List<IDisposable> disposableList;

    private E_TitleSceneState currentState;

    public TitleGameManager (){

        sceneLoadSubject = new Subject<E_SceneName>();

        //Iputを取得
        disposableList = new List<IDisposable>();
        var canvas = GameObject.Find("Canvas");

        var TitleInputManager = canvas.transform.Find("TitleUI").gameObject.GetComponent<TitleInputManager>();
        var optionManager = canvas.transform.Find("OptionUI").gameObject.GetComponent<TitleOptionManager>();

        SceneLoadSubject = new Subject<E_SceneName>();
        disposableList = new List<IDisposable>();


        //Titleでのオプションボタンを監視
        var disopsable = TitleInputManager.OptionButtonAsync
        .Subscribe((x)=>{
            currentState = E_TitleSceneState.Option;
        });

        disposableList.Add(disopsable);

        //Titleオプションでのタイトルへ戻るのを監視
        disopsable = optionManager.BackToTitleAsync
        .Subscribe((x)=>{
            currentState = E_TitleSceneState.Title;
        });

        disposableList.Add(disopsable);

        //ゲーム開始を監視
        disopsable = TitleInputManager.StartGameAsync.Subscribe((x)=>{
            //リソースを開放
            Resources.UnloadUnusedAssets();
            CoroutineHander.StopAllActiveCoroutine();
            sceneLoadSubject.OnNext(E_SceneName.TrainingScene);
        });

        disposableList.Add(disopsable);

        currentState = E_TitleSceneState.Title;

    }

    

    public IDisposable ObserveSceneLoadAlert(Action<E_SceneName> action){
        return sceneLoadSubject.Subscribe((type)=>{
            action(type);
        });
    }



    public void StartGame(){
        StateSubject.OnNext(currentState);
    }



    // このクラスがDisposeされたら購読も止める
    public void Dispose(){
        foreach (var disopsable in disposableList){
            disopsable.Dispose();
        }
    }
}
