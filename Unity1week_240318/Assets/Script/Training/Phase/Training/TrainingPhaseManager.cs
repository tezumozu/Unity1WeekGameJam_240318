using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TrainingPhaseManager : TrainingPhase{

    private TrainingTimer timer;
    private CountDownUIManager CountDownAnim;
    private FinishAnimUIManager FinishAnimUIManager;

    public TrainingPhaseManager(){
        var Canvas = GameObject.Find("Canvas");
        timer = GameObject.Find("TrainingUI").GetComponent<TrainingTimer>();
        CountDownAnim = Canvas.transform.Find("CountDownUI").gameObject.GetComponent<CountDownUIManager>();
        //FinishAnimUIManager = Canvas.transform.Find("FinishAnimUIManager").gameObject.GetComponent<FinishAnimUIManager>();
    }

    public override IEnumerator StartPhase(){


        //カウントダウンをする
        var isFinishCoroutine = CountDownAnim.StartCountDown();

        //アニメーション終了待ち
        CoroutineHander.OrderStartCoroutine(isFinishCoroutine);
        while(!(bool)isFinishCoroutine.Current){
            yield return null;
        }


        //トレーニング開始 トレーニング終了を待機
        isFinishCoroutine = timer.StartTimer();

        //タイマー終了待ち
        CoroutineHander.OrderStartCoroutine(isFinishCoroutine);
        while(!(bool)isFinishCoroutine.Current){
            yield return null;
        }


        //60秒経過したので終了の演出

        yield return null;
        StateFinishSubject.OnNext(Unit.Default);
    }
}
