using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomHI_I_Action : BattleActorAction{

    public VenomHI_I_Action():base(E_ActionType.VenomHI_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Poison || attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){

            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.AttackUP , 5},
                {E_Buff.NormalAttackUP , 5}
            };

            //バフを付与
            yield return attacker.AppliyBuff( buffList );
        }
    }
}
