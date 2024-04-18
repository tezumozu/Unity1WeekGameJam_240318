using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuff_Action : BattleActorAction{

    public DefenseBuff_Action():base(E_ActionType.DefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.DefenseUP ,5 );
    }
}
