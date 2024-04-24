using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDrain_Action : BattleActorAction{

    public PowerDrain_Action():base(E_ActionType.PowerDrain){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var attackPoint = diffender.GetCurrentEffectedStatus.Attack;
        yield return attacker.AppliyHeel( attackPoint );

        //バフを付与
        yield return diffender.ClearBuff( E_Buff.AttackUP );

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.AttackDown , 4 );
    }
}
