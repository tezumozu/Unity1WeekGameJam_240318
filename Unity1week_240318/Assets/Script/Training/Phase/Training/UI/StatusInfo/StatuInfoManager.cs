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

    [SerializeField]
    protected TrainingTimer timer;

    bool isActiveGame;
    protected bool isStatusMAX = false;

    private void Start() {

        isActiveGame = false;

        //Timerを監視
        timer.TimerActiveAsync
        .Subscribe((flag)=>{
            button.interactable = flag;
            isActiveGame = true;
        })
        .AddTo(this);
        
        manager.UpdateTrainingStatusAsync
        .Subscribe((status) => {
            UpdateText(status);

            if(!isActiveGame) return;

            if(status.SkillPoint != 0 && !isStatusMAX){
                button.interactable = true;
            }else{
                button.interactable = false;
            }
        })
        .AddTo(this);

        button.interactable = false;
    }

    protected abstract void UpdateText(S_SlimeTrainingData status);
}
