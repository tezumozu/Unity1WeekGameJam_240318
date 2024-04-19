using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDebuff_Action : BattleActorAction{

    public FlameDebuff_Action():base(E_ActionType.FlameDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.FlameDown , 5);
    }
}
