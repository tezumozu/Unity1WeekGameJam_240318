using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TrainingPhaseManager : TrainingPhase{
    public override IEnumerator StartPhase(){
        Debug.Log("Training");

        //カウントダウンをする

        //トレーニング開始 トレーニング終了を待機

        //60秒経過したので終了の演出

        yield return null;
        StateFinishSubject.OnNext(Unit.Default);
    }
}
