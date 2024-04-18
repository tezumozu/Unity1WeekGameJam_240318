using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHi_II_Action : BattleActorAction{

    public PoisonHi_II_Action():base(E_ActionType.PoisonHi_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Poison || attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){
            //バフを付与
            yield return attacker.AppliyEffect( E_BeforeStatusEffect.MPAccel );
        }
    }
}
