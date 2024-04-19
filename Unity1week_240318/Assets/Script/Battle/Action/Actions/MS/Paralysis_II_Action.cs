using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralysis_II_Action : BattleActorAction{

    public Paralysis_II_Action():base(E_ActionType.Paralysis_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyEffect( E_BeforeStatusEffect.Paralysis );
    }
}
