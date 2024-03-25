using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceEffect : BeforeStatusEffect{
    private int turnCount;


    public SilenceEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Silence,actionFactory){
    }

    public override BattleActorAction AppliyEffect(E_ActionType type){
        var action = actionFactory.CreateAction(type);
        if(action.ActionData.Cost > 0){
            return actionFactory.CreateAction(E_ActionType.Silence);
        }
        return action;
    }

    public override bool CheckContinueEffect(){
        turnCount--;
        if(turnCount == 0){
            return false;
        }
        return true;
    }
}
