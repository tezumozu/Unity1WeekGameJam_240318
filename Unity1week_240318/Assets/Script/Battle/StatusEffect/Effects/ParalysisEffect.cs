using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalysisEffect : BeforeStatusEffect{

    public ParalysisEffect(I_ActionCreatable actionFactory):base(actionFactory){
        Type = E_BeforeStatusEffect.Paralysis;

        EffectName = "麻痺";

        EffectText = "は麻痺している！";
        EffectAction = actionFactory.CreateAction(E_ActionType.Paralysis);
        RecoveryText = "は麻痺が治った！";
    }

    public override bool AppliyEffect(BattleActor actor){
        if(Random.Range(0.0f,0.1f) < 0.3f){
            return true;
        }

        return false;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
