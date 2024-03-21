using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class StateCheckTurnUpdater : TurnUpdater{

    private BattleActor tartget;

    public StateCheckTurnUpdater(BattleActor tartget){
        this.tartget = tartget;
    }

    public override IEnumerator StartTurn(){
        Debug.Log("状態異常チェック");

        float cTime = 0.0f;
        while (cTime < 1.0f){
            cTime += Time.deltaTime;
            yield return null;
        }

        FinishTurnSubject.OnNext(Unit.Default);
    }

    public override void Dispose(){
        
    }
}
