using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;
using Zenject;

public class BattleObjectUpdater : I_SceneObjectUpdatable{
    
    BattleSceneManager gameManager;

    public I_SceneLoadAlertable InitObject(){
        gameManager = new BattleSceneManager();
        return gameManager;
    }


    public void StartGame(){
        gameManager.StartBattle();
    }


    public void UpdateObject(){
    }


    public void ReleaseObject(){
        gameManager.Dispose();
    }

}
