using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDebuff_Action : BattleActorAction{

    public IceDebuff_Action():base(E_ActionType.IceDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
            yield return diffender.AppliyDeBuff( E_Buff.IceDown , 4 );
    }
}
