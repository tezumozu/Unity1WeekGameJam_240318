using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndParalysisCure_Action : BattleActorAction{

    public DefenseAndParalysisCure_Action():base(E_ActionType.DefenseAndParalysisCure){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.Defense , 1 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            //バフを付与
            yield return attacker.AppliyHeel( attacker.GetMaxStatus.HP * 3 / 10 );
        }
    }
}
