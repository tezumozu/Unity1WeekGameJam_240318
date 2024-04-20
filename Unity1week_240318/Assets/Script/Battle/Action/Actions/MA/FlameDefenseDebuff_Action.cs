using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDefenseDebuff_Action : BattleActorAction{

    public FlameDefenseDebuff_Action():base(E_ActionType.FlameDefenseDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyDeBuff( E_Buff.FlameResistanceDown , 4 );
    }
}
