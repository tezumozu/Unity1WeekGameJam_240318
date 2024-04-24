using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class ExpButton : MonoBehaviour{

    [SerializeField]
    ExpInfo info;

    [SerializeField]
    Button button;

    [SerializeField]
    TrainingTimer timer;

    // Start is called before the first frame update
    void Start(){

        info.LevelMaxAsync
        .Subscribe((_)=>{
            button.interactable = false;
        })
        .AddTo(this);

        //タイマーを監視
        timer.TimerActiveAsync.Subscribe((flag) => {
            button.interactable = flag;
        }).AddTo(this);

        button.interactable = false;
        
    }
}
