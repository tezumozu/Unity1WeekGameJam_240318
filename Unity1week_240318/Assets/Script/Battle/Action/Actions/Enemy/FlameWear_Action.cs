using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWear_Action : BattleActorAction{

    public FlameWear_Action():base(E_ActionType.FlameWear){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.FlameUP , 5 );
    }
}
