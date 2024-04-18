using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomHI_III_Action : BattleActorAction{

    public VenomHI_III_Action():base(E_ActionType.VenomHI_III){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var damage = base.UseAction(effectedStatus,attacker,diffender);

        yield return damage;

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Poison || attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){
            //バフを付与
            yield return attacker.AppliyHeel( (int)damage.Current / 2 ) ;
        }
    }
}
