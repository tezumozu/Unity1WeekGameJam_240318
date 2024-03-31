using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceEffect : BeforeStatusEffect{
    private int turnCount;


    public SilenceEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Silence,actionFactory){
    }

    public override BattleActorAction AppliyEffect(BattleActorAction action){

        if(action.ActionData.AttackType == E_AttackType.Magic){
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
