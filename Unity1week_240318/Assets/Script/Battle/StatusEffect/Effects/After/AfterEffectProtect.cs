using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEffectProtect : AfterStatusEffect{
    int turnCount;

    public AfterEffectProtect():base(E_AfterStatusEffect.EffectProtect){
        turnCount = 4;
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        yield return null;
    }

    public override bool CheckContinueEffect(){
        turnCount--;
        if(turnCount <= 0){
            return false;
        }
        return true;
    }
}
