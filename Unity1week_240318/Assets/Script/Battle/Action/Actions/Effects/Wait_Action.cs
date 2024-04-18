using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait_Action : BattleActorAction{

    public Wait_Action():base(E_ActionType.Wait){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //何もしない
        yield return null;
    }
}
