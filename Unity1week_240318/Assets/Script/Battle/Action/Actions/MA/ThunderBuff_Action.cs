using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBuff_Action : BattleActorAction{

    public ThunderBuff_Action():base(E_ActionType.ThunderBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return attacker.AppliyBuff( E_Buff.ThunderUP , 5 );
    }
}
