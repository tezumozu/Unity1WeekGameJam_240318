using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisEffect_Action : BattleActorAction{

    public ParalysisEffect_Action():base(E_ActionType.ParalysisEffect){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //何もしない
        yield return null;
    }
}
