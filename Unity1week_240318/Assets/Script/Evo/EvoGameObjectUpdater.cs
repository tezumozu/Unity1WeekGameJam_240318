using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;

using Zenject;

public class EvoGameObjectUpdater : I_SceneObjectUpdatable{
    [Inject]
    EvoGameManager gameManager;


    public I_SceneLoadAlertable InitObject(){
        return gameManager;
    }


    public void StartGame(){
        gameManager.StartGame();
    }


    public void UpdateObject(){

    }


    public void ReleaseObject(){
        gameManager.Dispose();
    }
}
