using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisEffect : BeforeStatusEffect{

    int currentTrun;

    public ParalysisEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Paralysis,actionFactory){
        currentTrun = 5;
    }

    public override BattleActorAction AppliyEffect(BattleActorAction action){
        if(Random.Range(0.0f,1.0f) < 0.5f){
            return actionFactory.CreateAction(E_ActionType.ParalysisEffect);
        }

        return action;
    }

    public override bool CheckContinueEffect(){
        currentTrun--;
        if(currentTrun > 0){
            return true;
        }

        return false;
    }
}
