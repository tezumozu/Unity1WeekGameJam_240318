using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAccel_Action : BattleActorAction{

    public MPAccel_Action():base(E_ActionType.MPAccel){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return CoroutineHander.OrderStartCoroutine(attacker.AppliyEffect( E_BeforeStatusEffect.MPAccel ));
    }
}
