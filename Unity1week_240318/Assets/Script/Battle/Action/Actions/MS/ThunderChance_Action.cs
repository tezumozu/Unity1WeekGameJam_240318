using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderChance_Action : BattleActorAction{

    public ThunderChance_Action():base(E_ActionType.ThunderChance){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.ThunderUP , 5 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            effectedStatus = attacker.GetCurrentEffectedStatus;
            yield return base.UseAction(effectedStatus,attacker,diffender);

        }
    }
}
