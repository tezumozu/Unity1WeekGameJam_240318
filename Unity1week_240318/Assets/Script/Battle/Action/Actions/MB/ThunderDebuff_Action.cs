using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDebuff_Action : BattleActorAction{

    public ThunderDebuff_Action():base(E_ActionType.ThunderDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyDeBuff( E_Buff.ThunderDown , 4 );
    }
}
