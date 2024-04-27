using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureStatus_Action : BattleActorAction{

    public CureStatus_Action():base(E_ActionType.CureStatus){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //状態異常回復
        yield return attacker.ClearEffect( E_BuffType.Debuff );
    }
}
