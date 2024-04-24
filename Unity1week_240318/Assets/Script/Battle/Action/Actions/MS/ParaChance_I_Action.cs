using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaChance_I_Action : BattleActorAction{

    public ParaChance_I_Action():base(E_ActionType.ParaChance_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){
            ActionData.Power = ActionData.Power * 2;
        }

        yield return base.UseAction( effectedStatus , attacker , diffender );
    }
}
