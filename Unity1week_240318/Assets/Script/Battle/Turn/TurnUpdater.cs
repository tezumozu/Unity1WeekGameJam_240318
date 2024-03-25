using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TurnUpdater : IDisposable{

    
    protected Subject<Unit> FinishTurnSubject;
    public IObservable<Unit> FinishTurnAsync => FinishTurnSubject;

    private BattleActor attacker;
    private BattleActor defender;

    private bool isFinished;

    IDisposable attackerDeadDisposable;
    IDisposable defenderDeadDisposable;



    public TurnUpdater(BattleActor attacker,BattleActor defender){
        FinishTurnSubject = new Subject<Unit>();

        this.attacker = attacker;
        this.defender = defender;

        isFinished = false;

        //死亡判定
        attackerDeadDisposable = attacker.isDeadAsync.Subscribe((x)=>{
            isFinished = true;
        });

        defenderDeadDisposable = defender.isDeadAsync.Subscribe((x)=>{
            isFinished = true;
        });
    }



    public IEnumerator StartTurn(){

        //Actionを取得する
        yield return attacker.SetNextAction();

        //状態異常タイプAをチェック（麻痺）
        yield return attacker.CheckBeforeStatusEffect();

        ////Actionを処理
        yield return attacker.ActionBattleActor(defender);

        //勝敗チェック
        if(isFinished){
            FinishTurnSubject.OnNext(Unit.Default);
            yield break;
        }

        //状態異常タイプBをチェック（毒、猛毒）
       yield return attacker.CheckAfterStatusEffect();

        //勝敗チェック
        if(isFinished){
            FinishTurnSubject.OnNext(Unit.Default);
            yield break;
        }

        //リフレッシュ、状態異常や騒動不可、バフの消失などフラグの修正
        yield return attacker.RefreshBattleActor();

        FinishTurnSubject.OnNext(Unit.Default);
    }



    public void Dispose(){
        attackerDeadDisposable.Dispose();
        defenderDeadDisposable.Dispose();
    }
}
