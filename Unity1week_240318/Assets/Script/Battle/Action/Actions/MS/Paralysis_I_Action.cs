using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralysis_I_Action : BattleActorAction{

    public Paralysis_I_Action():base(E_ActionType.Paralysis_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return diffender.AppliyEffect( E_BeforeStatusEffect.Paralysis );
    }
}
