using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;

using Zenject;

public class TrainingObjectUpdater : I_SceneObjectUpdatable{

    [Inject]
    private TrainingGameManager gameManager;

    public I_SceneLoadAlertable InitObject(){
        return gameManager;
    }


    public void UpdateObject(){

    }


    public void ReleaseObject(){

    }


    public void StartGame(){
        gameManager.StartGame();
    }
}
