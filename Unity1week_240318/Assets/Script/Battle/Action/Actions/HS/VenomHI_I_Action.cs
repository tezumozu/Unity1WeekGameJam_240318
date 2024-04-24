using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomHI_I_Action : BattleActorAction{

    public VenomHI_I_Action():base(E_ActionType.VenomHI_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){
            ActionData.Power = 120;
            ActionData.Element = E_Element.TrueDamage;
            
        }

        yield return base.UseAction(effectedStatus,attacker,diffender);
    }
}
