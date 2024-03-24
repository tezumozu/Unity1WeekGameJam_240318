using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBombEffect : AfterStatusEffect{
    private int turnCount;

    public TimeBombEffect(){
        turnCount = 4;
        Type = E_AfterStatusEffect.TimeBomb;
        EffectName = "時限爆弾";

        EffectText = "時限爆弾のカウントが進む！";
        RecoveryText = "時限爆弾は消え去った！";
    }

    public override List<string> AppliyEffect(BattleActor actor){
        var resultTextList = new List<string>();
        turnCount--;
        if(turnCount == 0){
            int damagePoint = actor.GetMaxStatus.HP/4;
            actor.DamageAppliy(damagePoint,E_Element.TrueDamage);
            resultTextList.Add(actor.GetCurrentStatus.Name + "は爆破ダメージを受けた！");
        }else{
            resultTextList.Add("残り " + turnCount + " カウント！");
        }
        return resultTextList;
    }

    public override bool CheckContinueEffect(){
        if(turnCount == 0){
            return false;
        }
        return true;
    }
}
