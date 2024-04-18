using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure_I_Action : BattleActorAction{

    public Cure_I_Action():base(E_ActionType.Cure_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return CoroutineHander.OrderStartCoroutine(attacker.AppliyHeel( attacker.GetMaxStatus.HP/4 ));
    }
}
