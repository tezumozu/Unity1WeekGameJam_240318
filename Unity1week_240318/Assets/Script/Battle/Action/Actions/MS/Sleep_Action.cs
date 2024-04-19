using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep_Action : BattleActorAction{

    public Sleep_Action():base(E_ActionType.Sleep){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyEffect( E_BeforeStatusEffect.Sleep );
    }
}
