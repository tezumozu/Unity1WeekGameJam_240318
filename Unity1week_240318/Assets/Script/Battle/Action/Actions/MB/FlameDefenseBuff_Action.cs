using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDefenseBuff_Action : BattleActorAction{

    public FlameDefenseBuff_Action():base(E_ActionType.FlameDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.FlameResistanceUP , 5 );
    }
}
