using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDefenseDebuff_Action : BattleActorAction{

    public IceDefenseDebuff_Action():base(E_ActionType.IceDefenseDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyDeBuff( E_Buff.IceResistanceDown , 4 );
    }
}
