using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;

using Zenject;

public class TrainingObjectUpdater : I_SceneObjectUpdatable{

    [Inject]
    private TrainingGameManager gameManager;

    [Inject]
    private SlimeTrainingManager SlimeTrainingManager;

    public I_SceneLoadAlertable InitObject(){
        return gameManager;
    }


    public void UpdateObject(){
        SlimeTrainingManager.UpdateStatus();
    }  


    public void ReleaseObject(){
        gameManager.Dispose();
        SlimeTrainingManager.Dispose();
    }


    public void StartGame(){
        gameManager.StartGame();
        
    }
}
