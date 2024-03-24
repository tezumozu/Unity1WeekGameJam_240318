using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEffect : AfterStatusEffect{

    public VenomEffect(){
        Type = E_AfterStatusEffect.Venom;
        EffectName = "猛毒";

        EffectText = "は猛毒を受けている！";
        RecoveryText = "の猛毒は回復した！";
    }

    public override List<string> AppliyEffect(BattleActor actor){
        var resultTextList = new List<string>();
        resultTextList.Add(actor.GetCurrentStatus.Name + "は猛毒のダメージを受けた！");
        return resultTextList;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
