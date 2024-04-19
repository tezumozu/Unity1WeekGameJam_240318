using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regene_Action : BattleActorAction{

    public Regene_Action():base(E_ActionType.Regene){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyEffect( E_AfterStatusEffect.Regene );
    }
}
