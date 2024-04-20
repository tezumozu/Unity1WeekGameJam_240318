using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAttack_II_Action : BattleActorAction{

    public SleepAttack_II_Action():base(E_ActionType.SleepAttack_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(UnityEngine.Random.Range(0.0f,1.0f) < 0.6f){
            //バフを付与
            yield return diffender.AppliyEffect( E_BeforeStatusEffect.Sleep );
        }
    }
}
