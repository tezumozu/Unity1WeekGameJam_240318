using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDefenseDebuff_Action : BattleActorAction{

    public ThunderDefenseDebuff_Action():base(E_ActionType.ThunderDefenseDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyDeBuff( E_Buff.ThunderResistanceDown , 5 );
    }
}
