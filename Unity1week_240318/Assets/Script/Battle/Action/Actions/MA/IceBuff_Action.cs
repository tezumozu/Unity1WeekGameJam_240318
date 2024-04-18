using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBuff_Action : BattleActorAction{

    public IceBuff_Action():base(E_ActionType.IceBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.IceUP , 5 );
    }
}
