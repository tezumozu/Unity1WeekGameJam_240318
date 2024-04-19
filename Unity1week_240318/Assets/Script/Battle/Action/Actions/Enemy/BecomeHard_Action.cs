using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeHard_Action : BattleActorAction{

    public BecomeHard_Action():base(E_ActionType.BecomeHard){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.DefenseUP , 3 );
    }
}
