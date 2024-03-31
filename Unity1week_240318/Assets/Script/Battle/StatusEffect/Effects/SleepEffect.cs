using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepEffect : BeforeStatusEffect{
    private int turnCount;

    public SleepEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Sleep,actionFactory){
        turnCount = 2;
    }

    public override BattleActorAction AppliyEffect(BattleActorAction action){

        return actionFactory.CreateAction(E_ActionType.Sleep);
    }

    public override bool CheckContinueEffect(){
        turnCount--;
        if(turnCount == 0){
            return false;
        }
        return true;
    }
}
