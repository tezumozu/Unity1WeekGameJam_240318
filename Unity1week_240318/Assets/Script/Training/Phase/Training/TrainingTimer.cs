using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UniRx;
using Zenject;

public class TrainingTimer : MonoBehaviour{
    [SerializeField]
    TextMeshProUGUI TimerNum;

    [Inject]
    TrainingGameManager gameManager;

    [SerializeField]
    float LimitTime;

    private float currentTime;
    private bool isActive;

    private Subject<bool> TimerActiveSucject = new Subject<bool>();
    public Subject<bool> TimerActiveAsync => TimerActiveSucject;

    void Start(){
        isActive = true;
        TimerNum.text = LimitTime.ToString();

        //ポーズを監視
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            isActive = flag;
        })
        .AddTo(this);
    }


    public IEnumerator StartTimer(){

        currentTime = 0.0f;
        TimerActiveSucject.OnNext(true);

        while(currentTime < LimitTime){

            if(!isActive){
                yield return false;
                continue;
            }

            currentTime += Time.deltaTime;
            TimerNum.text = (LimitTime - (int)currentTime).ToString();
            yield return false;
        }

        yield return true;

        TimerActiveSucject.OnNext(false);

    }
}
