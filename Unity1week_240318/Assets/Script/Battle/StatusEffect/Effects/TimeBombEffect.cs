using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBombEffect : AfterStatusEffect{
    private int turnCount;

    public TimeBombEffect():base(E_AfterStatusEffect.TimeBomb){
        turnCount = 4;
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        turnCount--;
        if(turnCount == 0){
            int damagePoint = actor.GetMaxStatus.HP/3;
            yield return actor.AppliyDamage(damagePoint,E_Element.TrueDamage);
        }else{
            if(turnCount-1 == 0){
                EffectData.EffectText = ("のボムが爆発した！");
            }else{
                EffectData.EffectText = ("爆発まで残り " + (turnCount - 1) + " ！");
            }
            yield return null;
        }
    }

    public override bool CheckContinueEffect(){
        if(turnCount == 0){
            return false;
        }
        return true;
    }
}
