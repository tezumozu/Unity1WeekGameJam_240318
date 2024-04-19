using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceCurse_Action : BattleActorAction{

    public SilenceCurse_Action():base(E_ActionType.SilenceCurse){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return diffender.AppliyEffect( E_BeforeStatusEffect.Silence );
    }
}
