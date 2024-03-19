using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;
using UniRx;

public class BattleSceneManager : I_SceneLoadAlertable{

    private Subject<E_SceneName> sceneLoadSubject = new Subject<E_SceneName>();
    private E_SceneState currentState;
    private E_EnemyType[] enemyList = new E_EnemyType[5];

    public BattleSceneManager(){
        currentState = E_SceneState.Init;
    }

    public void StartBattle(){
        currentState = E_SceneState.Battle;

    }

    public void ObserveSceneLoadAlert(Action<E_SceneName> action){
        sceneLoadSubject.Subscribe((x) => action(x));
    }
}
