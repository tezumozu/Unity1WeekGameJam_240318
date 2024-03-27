using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;
using UniRx;

public class BattleSceneManager : I_SceneLoadAlertable,IDisposable{

    private BattleManager battleManager;    
    private E_EnemyType[] enemyList = new E_EnemyType[5];

    private readonly List<IDisposable> disposableList;

    private Subject<E_SceneName> sceneLoadSubject = new Subject<E_SceneName>();

    private static ReactiveProperty<E_BattleSceneState> currentState = new ReactiveProperty<E_BattleSceneState>();
    public static IObservable<E_BattleSceneState> currentStateAsync => currentState;

    public BattleSceneManager(){

        //テスト用
        //テスト用のスキルリスト
        var skillList = new List<E_ActionType>();
        skillList.Add(E_ActionType.Flame_1);
        skillList.Add(E_ActionType.Flame_2);
        skillList.Add(E_ActionType.Flame_3);
        skillList.Add(E_ActionType.Cure_1);
        skillList.Add(E_ActionType.Cure_2);
        skillList.Add(E_ActionType.Cure_3);
        skillList.Add(E_ActionType.HiAttack_1);

        //初期値を代入
        currentState.Value = E_BattleSceneState.Init;

        //必要なクラスの取得、初期化
        disposableList = new List<IDisposable>();
        battleManager = new BattleManager();
        var battleInputManager = GameObject.Find("BattleInputManager").GetComponent<BattleInputManager>();
        var resultInputManager = GameObject.Find("ResultInputManager").GetComponent<ResultInputManager>();
        var pauseInputManager = GameObject.Find("PauseInputManager").GetComponent<PauseInputManager>();
        var pauseUIManager = GameObject.Find("Canvas/PauseUI").GetComponent<PauseUIManager>();

        pauseUIManager.SetActive(false);


        //バトルマネージャの終了を監視
        var disopsable = battleManager.battleFinisheAsync.Subscribe((x)=>{
            currentState.Value = E_BattleSceneState.Result;
        });

        disposableList.Add(disopsable);


        //escの入力を監視
        disopsable = battleInputManager.escAsync.Subscribe((x)=>{
            currentState.Value = E_BattleSceneState.Pause;
            pauseUIManager.SetActive(true);
        });

        disposableList.Add(disopsable);


        disopsable = pauseInputManager.escAsync.Subscribe((x)=>{
            currentState.Value = E_BattleSceneState.Battle;
            pauseUIManager.SetActive(false);
        });

        disposableList.Add(disopsable);


        //リザルト終了の監視
        disopsable = resultInputManager.ResultUIAsync.Subscribe((x)=>{
            //リソースを開放
            Resources.UnloadUnusedAssets();
            sceneLoadSubject.OnNext(E_SceneName.TitleScene);
        });

        disposableList.Add(disopsable);


        //タイトルへ戻るか監視
        disopsable = pauseUIManager.BackToTitleAsync.Subscribe((x)=>{
            //リソースを開放
            Resources.UnloadUnusedAssets();
            CoroutineHander.StopAllCoroutine();
            sceneLoadSubject.OnNext(E_SceneName.TitleScene);
        });

        disposableList.Add(disopsable);



        //テスト用
        disopsable = currentStateAsync.Subscribe((x)=>{
            Debug.Log(x);
        });

        disposableList.Add(disopsable);

    }



    public void StartBattle(){
        currentState.Value = E_BattleSceneState.Battle;
        battleManager.StartBattle();
    
    }


    public IDisposable ObserveSceneLoadAlert(Action<E_SceneName> action){
        return sceneLoadSubject.Subscribe((x) => action(x));
    }


    // このクラスがDisposeされたら購読も止める
    public void Dispose(){
        foreach (var disopsable in disposableList){
            disopsable.Dispose();
        }
        

        //バトルマネージャの購読終了
        battleManager.Dispose();
    }
}
