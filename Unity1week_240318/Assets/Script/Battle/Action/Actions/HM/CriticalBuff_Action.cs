using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalBuff_Action : BattleActorAction{

    public CriticalBuff_Action():base(E_ActionType.CriticalBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return CoroutineHander.OrderStartCoroutine(attacker.AppliyBuff( E_Buff.CriticalUP ,5 ));
    }
}
