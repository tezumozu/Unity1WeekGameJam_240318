using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBeforeEffect : BeforeStatusEffect{


    public NonBeforeEffect(I_ActionCreatable actionFactory):base(E_BeforeStatusEffect.Non,actionFactory){
    }

    public override BattleActorAction AppliyEffect(E_ActionType type){
        return actionFactory.CreateAction(type);
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
