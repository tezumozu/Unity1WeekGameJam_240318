using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAndSleepResetStaus_Action : BattleActorAction{

    public AtackAndSleepResetStaus_Action():base(E_ActionType.AtackAndSleepResetStaus){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Sleep){

            //バフを付与
            yield return diffender.ClearBuff( E_BuffType.Buff );
            yield return diffender.ClearEffect( E_BuffType.Buff );
        }
    }
}
