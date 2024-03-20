using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattlePhase : PhaseUpdater{
    //Start時の演出処理
    public override IEnumerator UpdatePhase (S_BattleDate data){
    
        Debug.Log("第 " + (data.WinCount + 1) + "の敵が現れた");
        float cTime = 0.0f;
        while (cTime < 5.0f){
            cTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("敵を倒した");
        cTime = 0.0f;
        while (cTime < 5.0f){
            cTime += Time.deltaTime;
            yield return null;
        }

        FinishPhaseSubject.OnNext(Unit.Default);

    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        
    }

}
