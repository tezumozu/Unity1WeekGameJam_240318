using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonAfterEffect : AfterStatusEffect{

    public NonAfterEffect(){
        Type = E_AfterStatusEffect.Non;
        EffectName ="Non";
        EffectText = "";
        RecoveryText = "";
    }

    public override List<string> AppliyEffect(BattleActor actor){
        var resultTextList = new List<string>();
        return resultTextList;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
