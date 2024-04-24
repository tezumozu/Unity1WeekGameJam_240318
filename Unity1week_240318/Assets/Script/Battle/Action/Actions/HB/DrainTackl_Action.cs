using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainTackl_Action : BattleActorAction{

    public DrainTackl_Action():base(E_ActionType.DrainTackl){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var damage = base.UseAction(effectedStatus,attacker,diffender);
        yield return damage;

        //バフを付与
        yield return attacker.AppliyHeel( (int)damage.Current / 2  );
    }

    protected override int CalculateAttackPoint(S_BattleActorStatus effectedStatus){
        return (int)((float)effectedStatus.Defense * (float)ActionData.Power * (float)effectedStatus.Level) ;
    }
}
