using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaChance_II_Action : BattleActorAction{

    public ParaChance_II_Action():base(E_ActionType.ParaChance_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){
            ActionData.Element = diffender.GetCurrentStatus.Weakness;
            effectedStatus = attacker.GetCurrentEffectedStatus;
        }

        yield return base.UseAction( effectedStatus , attacker , diffender );
    }
}
