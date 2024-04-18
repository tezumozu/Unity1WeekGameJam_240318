using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEffect : AfterStatusEffect{

    int currentTrue;

    public VenomEffect() :base(E_AfterStatusEffect.Venom){
        currentTrue = 5;
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        int damage = (int)((float)actor.GetMaxStatus.HP / 16);
        return actor.AppliyDamage(damage,E_Element.Constant);
    }

    public override bool CheckContinueEffect(){
        currentTrue--;
        if(currentTrue <= 0){
            return false;
        }
        return true;
    }
}
