using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_Action : BattleActorAction{

    public Poison_Action():base(E_ActionType.Poison){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return diffender.AppliyEffect( E_AfterStatusEffect.Poison );
    }
}
