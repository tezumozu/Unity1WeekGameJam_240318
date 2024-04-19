using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDefenseBuff_Action : BattleActorAction{

    public IceDefenseBuff_Action():base(E_ActionType.IceDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
            yield return attacker.AppliyBuff( E_Buff.IceResistanceUP , 5 );
    }
}
