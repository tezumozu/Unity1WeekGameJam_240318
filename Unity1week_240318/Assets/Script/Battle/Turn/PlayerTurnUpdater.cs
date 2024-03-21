using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class PlayerTurnUpdater : TurnUpdater{

    private BattleActor player;
    private BattleActor enemy;

    public PlayerTurnUpdater(BattleActor player,BattleActor enemy){
        this.player = player;
        this.enemy = enemy;
    }


    public override IEnumerator StartTurn(){
        //テスト
        Debug.Log("プレイヤーターン");

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
