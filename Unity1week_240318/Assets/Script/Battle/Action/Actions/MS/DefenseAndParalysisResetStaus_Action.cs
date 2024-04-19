using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndParalysisResetStaus_Action : BattleActorAction{

    public DefenseAndParalysisResetStaus_Action():base(E_ActionType.DefenseAndParalysisResetStaus){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.Defense , 1 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            //バフを付与
            yield return attacker.ClearBuff( E_BuffType.Debuff );
            yield return attacker.ClearEffect( E_BuffType.Debuff );
        }
    }
}
