using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEffect : AfterStatusEffect{

    int currentTrue;

    public VenomEffect() :base(E_AfterStatusEffect.Venom){
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        int damage = actor.GetMaxStatus.HP / 8;
        return actor.AppliyDamage(damage,E_Element.TrueDamage);
    }

    public override bool CheckContinueEffect(){
        currentTrue--;
        if(currentTrue <= 0){
            return false;
        }
        return true;
    }
}
