using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EnemyTurnUpdater : TurnUpdater{

    private BattleActor player;
    private BattleActor enemy;

    public EnemyTurnUpdater(BattleActor player,BattleActor enemy){
        this.player = player;
        this.enemy = enemy;
    }


    public override IEnumerator StartTurn(){
        //テスト
        Debug.Log("エネミーターン終了");
        Debug.Log("エネミー敗北");

        float cTime = 0.0f;
        while (cTime < 1.0f){
            cTime += Time.deltaTime;
            yield return null;
        }

        enemy.test();
        FinishTurnSubject.OnNext(Unit.Default);
    }

    public override void Dispose(){
        
    }
}
