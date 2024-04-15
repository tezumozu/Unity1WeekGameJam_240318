using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public abstract class StatuInfoManager : MonoBehaviour{

    [Inject]
    protected SlimeTrainingManager manager;

    [SerializeField]
    protected TextMeshProUGUI LevelNum;

    [SerializeField]
    protected TextMeshProUGUI StatusNum;

    [SerializeField]
    protected Button button;

    [Inject]
    protected TrainingGameManager gameManager;

    [SerializeField]
    protected TrainingTimer timer;

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
            UpdateText(status);
            if(status.SkillPoint == 0){
                button.interactable = false;
            }else{
                button.interactable = true;
            }
        })
        .AddTo(this);
    }

    protected abstract void UpdateText(S_SlimeTrainingData status);
}
