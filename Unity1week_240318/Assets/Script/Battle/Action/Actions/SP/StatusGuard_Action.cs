using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusGuard_Action : BattleActorAction{

    public StatusGuard_Action():base(E_ActionType.StatusGuard){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyEffect( E_BeforeStatusEffect.EffectProtect );
        yield return attacker.AppliyEffect( E_AfterStatusEffect.EffectProtect );
    }
}
