using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class AttackInfo : MonoBehaviour{
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
            LevelNum.text = status.AttackLevel.ToString();
            StatusNum.text = status.Attack.ToString();
            if(status.AttackLevel == 100){
                LevelNum.text = "MAX";
                button.interactable = false;
            }
        })
        .AddTo(this);
    }
}
