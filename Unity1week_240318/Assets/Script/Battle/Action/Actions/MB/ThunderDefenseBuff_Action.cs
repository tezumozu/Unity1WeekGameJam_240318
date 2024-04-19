using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDefenseBuff_Action : BattleActorAction{

    public ThunderDefenseBuff_Action():base(E_ActionType.ThunderDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.ThunderResistanceUP , 5 );
    }
}
