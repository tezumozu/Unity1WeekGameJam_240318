using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHi_I_Action : BattleActorAction{

    public PoisonHi_I_Action():base(E_ActionType.PoisonHi_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Poison || attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){
            ActionData.Power = ActionData.Power*2;
        }

        yield return base.UseAction(effectedStatus,attacker,diffender);

        
    }
}
