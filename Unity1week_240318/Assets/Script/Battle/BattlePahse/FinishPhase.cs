using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class FinishPhase : PhaseUpdater{
    //Start時の演出処理
    public override IEnumerator UpdatePhase (S_BattleDate data){

        float cTime = 0.0f;
        Debug.Log("プレイヤーの勝利！");
        
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
