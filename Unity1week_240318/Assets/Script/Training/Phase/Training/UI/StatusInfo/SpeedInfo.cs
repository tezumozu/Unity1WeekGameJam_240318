using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class SpeedInfo : MonoBehaviour{
    [Inject]
    SlimeTrainingManager manager;

    [SerializeField]
    TextMeshProUGUI LevelNum;

    [SerializeField]
    TextMeshProUGUI StatusNum;

    [SerializeField]
    Button button;

    [Inject]
    TrainingGameManager gameManager;

    [SerializeField]
    TrainingTimer timer;

    private void Start() {

        //ポーズを監視
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            button.interactable = !flag;
        })
        .AddTo(this);


        //Timerを監視
        timer.TimerActiveAsync
        .Subscribe((flag)=>{
             button.interactable = flag;
        })
        .AddTo(this);

        button.interactable = false;
        
        manager.UpdateTrainingStatusAsync
        .Subscribe((status) => {
            StatusNum.text = status.Speed.ToString();
            LevelNum.text = status.SpeedLevel.ToString();
            if(status.SpeedLevel == 100){
                LevelNum.text = "MAX";
                button.interactable = false;
            }
        })
        .AddTo(this);
    }
}
