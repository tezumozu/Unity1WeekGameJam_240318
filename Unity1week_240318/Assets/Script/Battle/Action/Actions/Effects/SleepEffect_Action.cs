using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepEffect_Action : BattleActorAction{

    public SleepEffect_Action():base(E_ActionType.SleepEffect){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //何もしない
        yield return null;
    }
}
