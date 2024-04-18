using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPAccelEffect : BeforeStatusEffect{

    int currentTrue;

    public MPAccelEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.MPAccel,actionFactory){
        currentTrue = 4;
    }

    public override BattleActorAction AppliyEffect(BattleActorAction action){
        //MPを半分にする
        action.ActionData.Cost = (int) ( (float)action.ActionData.Cost / 2.0f );
        return action;
    }

    public override bool CheckContinueEffect(){
        currentTrue--;
        if(currentTrue <= 0){
            return false;
        }
        return true;
    }
}
