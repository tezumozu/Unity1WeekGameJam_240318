using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisEffect : BeforeStatusEffect{

    public ParalysisEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Paralysis,actionFactory){
        
    }

    public override BattleActorAction AppliyEffect(E_ActionType type){
        if(Random.Range(0.0f,0.1f) < 0.3f){
            return actionFactory.CreateAction(E_ActionType.Paralysis);
        }

        return actionFactory.CreateAction(type);
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
