using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisEffect : BeforeStatusEffect{

    public ParalysisEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Paralysis,actionFactory){
        
    }

    public override BattleActorAction AppliyEffect(BattleActorAction action){
        if(Random.Range(0.0f,1.0f) < 0.3f){
            return actionFactory.CreateAction(E_ActionType.Paralysis);
        }

        return action;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
