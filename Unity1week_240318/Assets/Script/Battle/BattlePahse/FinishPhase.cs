using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class FinishPhase : PhaseUpdater{
    //Start時の演出処理
    public override IEnumerator StartUpdatePhase (S_BattleDate data){
        Debug.Log("プレイヤーの勝利！");

        FinishPhaseSubject.OnNext(Unit.Default);
        yield return null;
    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        
    }

}
