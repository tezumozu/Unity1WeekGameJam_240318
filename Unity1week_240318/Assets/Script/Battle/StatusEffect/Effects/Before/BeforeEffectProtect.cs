using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeEffectProtect : BeforeStatusEffect{
    int turnCount;

    public BeforeEffectProtect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.EffectProtect,actionFactory){
        turnCount = 4;
    }

    public override BattleActorAction AppliyEffect(BattleActorAction action){
        return action;
    }

    public override bool CheckContinueEffect(){
         turnCount--;
        if(turnCount <= 0){
            return false;
        }
        return true;
    }
}
