using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBeforeEffect : BeforeStatusEffect{


    public NonBeforeEffect(I_ActionCreatable actionFactory):base(actionFactory){
        Type = E_BeforeStatusEffect.Non;
        EffectName = "Non";
        EffectText = "";
        EffectAction = actionFactory.CreateAction(E_ActionType.Attack);
        RecoveryText = "";
    }

    public override bool AppliyEffect(BattleActor actor){
        return false;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
