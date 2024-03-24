using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceEffect : BeforeStatusEffect{
    private int turnCount;


    public SilenceEffect(I_ActionCreatable actionFactory):base(actionFactory){
        Type = E_BeforeStatusEffect.Silence;
        turnCount = 4;
        EffectName = "沈黙";

        EffectText = "は沈黙している！";
        EffectAction = actionFactory.CreateAction(E_ActionType.Silence);
        RecoveryText = "の沈黙はとかれた！";
    }

    public override bool AppliyEffect(BattleActor actor){
        if(actor.CurrentAction.ActionData.Cost > 0){
            return true;
        }
        return false;
    }

    public override bool CheckContinueEffect(){
        turnCount--;
        if(turnCount == 0){
            return false;
        }
        return true;
    }
}
