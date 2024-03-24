using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepEffect : BeforeStatusEffect{
    private int turnCount;

    public SleepEffect(I_ActionCreatable actionFactory):base(actionFactory){
        Type = E_BeforeStatusEffect.Sleep;
        turnCount = 4;
        EffectName = "睡眠";

        EffectText = "は眠っている";
        EffectAction = actionFactory.CreateAction(E_ActionType.Sleep);
        RecoveryText = "は目を覚ました";
    }

    public override bool AppliyEffect(BattleActor actor){
        return true;
    }

    public override bool CheckContinueEffect(){
        turnCount--;
        if(turnCount == 0){
            return false;
        }
        return true;
    }
}
