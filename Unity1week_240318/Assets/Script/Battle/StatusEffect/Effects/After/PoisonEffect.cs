using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect: AfterStatusEffect{

    int currentTrue;

    public PoisonEffect():base(E_AfterStatusEffect.Poison){
        currentTrue = 5;
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        int damage = (int)((float)actor.GetMaxStatus.HP / 32);;
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
