using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect: AfterStatusEffect{

    public PoisonEffect(){
        Type = E_AfterStatusEffect.Poison;

        EffectName = "毒";

        EffectText = "は毒を受けている！";
        RecoveryText = "の毒は回復した！";
    }

    public override List<string> AppliyEffect(BattleActor actor){
        var resultTextList = new List<string>();
        resultTextList.Add(actor.GetCurrentStatus.Name + "は毒のダメージを受けた！");
        return resultTextList;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
