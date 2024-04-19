using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAndSleepAttackBuff_Action : BattleActorAction{

    public AtackAndSleepAttackBuff_Action():base(E_ActionType.AtackAndSleepAttackBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Sleep){

            //バフを付与
            yield return attacker.AppliyBuff( E_Buff.AttackUP , 5 );
        }
    }
}
