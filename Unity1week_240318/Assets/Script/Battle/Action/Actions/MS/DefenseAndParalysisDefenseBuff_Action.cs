using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndParalysisDefenseBuff_Action : BattleActorAction{

    public DefenseAndParalysisDefenseBuff_Action():base(E_ActionType.DefenseAndParalysisDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.Defense , 1 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            //バフを付与
            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.DefenseUP , 5},
                {E_Buff.FlameResistanceUP , 5},
                {E_Buff.IceResistanceUP , 5},
                {E_Buff.ThunderResistanceUP , 5}
            };

            //バフを付与
            yield return attacker.AppliyBuff( buffList );
        }
    }
}
