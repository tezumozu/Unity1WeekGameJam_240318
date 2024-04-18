using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDeBuff_Action : BattleActorAction{

    public AttackDeBuff_Action():base(E_ActionType.AttackDeBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.AttackDown , 5 );
    }
}
