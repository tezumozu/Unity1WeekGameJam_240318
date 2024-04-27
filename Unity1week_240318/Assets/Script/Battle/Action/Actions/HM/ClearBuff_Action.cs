using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBuff_Action : BattleActorAction{

    public ClearBuff_Action():base(E_ActionType.ClearBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return diffender.ClearBuff();

        yield return attacker.ClearBuff();
    }
}
