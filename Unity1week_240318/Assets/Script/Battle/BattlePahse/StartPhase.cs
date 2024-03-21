using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class StartPhase : PhaseUpdater{
    //Start時の演出処理
    public override IEnumerator StartUpdatePhase (S_BattleDate data){
        Debug.Log("第 " + (data.WinCount + 1) + " 層");

        float cTime = 0.0f;
        while (cTime < 1.0f){
            cTime += Time.deltaTime;
            yield return null;
        }

        FinishPhaseSubject.OnNext(Unit.Default);
    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){

    }
}
