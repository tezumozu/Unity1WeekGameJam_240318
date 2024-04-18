using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBuff_Action : BattleActorAction{

    public FlameBuff_Action():base(E_ActionType.FlameBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return attacker.AppliyBuff( E_Buff.FlameUP , 5 );
    }
}
