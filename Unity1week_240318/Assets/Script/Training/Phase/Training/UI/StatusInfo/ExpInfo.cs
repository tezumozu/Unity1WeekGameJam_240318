using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class ExpInfo : MonoBehaviour{
    [Inject]
    SlimeTrainingManager manager;

    [SerializeField]
    TextMeshProUGUI LevelNum;

    [SerializeField]
    Slider StatusNum;

    private Subject<Unit> LevelMaxSubject = new Subject<Unit>();
    public IObservable<Unit> LevelMaxAsync => LevelMaxSubject;

    private void Start() {

        //ステータス更新を監視
        manager.UpdateTrainingStatusAsync
        .Subscribe((status) => {
            StatusNum.value = (float)status.CurrentExp / (float)status.MaxExp;
            LevelNum.text = status.Level.ToString();

            if(status.Level == 100){
                LevelNum.text = "MAX";
                LevelMaxSubject.OnNext(Unit.Default);
            }
            
        })
        .AddTo(this);
    }
}
