using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndParalysisAttackDebuff_Action : BattleActorAction{

    public DefenseAndParalysisAttackDebuff_Action():base(E_ActionType.DefenseAndParalysisAttackDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.Defense , 1 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            //バフを付与
            yield return diffender.AppliyDeBuff( E_Buff.AttackDown , 4 );
        }
    }
}
