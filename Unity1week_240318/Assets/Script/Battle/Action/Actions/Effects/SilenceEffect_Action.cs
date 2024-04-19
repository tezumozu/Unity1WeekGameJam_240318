using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceEffect_Action : BattleActorAction{

    public SilenceEffect_Action():base(E_ActionType.SilenceEffect){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //何もしない
        yield return null;
    }
}
