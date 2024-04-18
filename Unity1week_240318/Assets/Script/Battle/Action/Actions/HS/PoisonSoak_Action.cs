using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSoak_Action : BattleActorAction{

    public PoisonSoak_Action():base(E_ActionType.PoisonSoak){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //状態異常付与
        yield return attacker.AppliyEffect( E_AfterStatusEffect.Poison );
        yield return diffender.AppliyEffect( E_AfterStatusEffect.Poison );
    }
}
