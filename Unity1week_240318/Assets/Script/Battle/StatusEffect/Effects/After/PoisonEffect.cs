using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect: AfterStatusEffect{

    public PoisonEffect():base(E_AfterStatusEffect.Poison){
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        int damage = actor.GetMaxStatus.HP / 16;
        return actor.AppliyDamage(damage,E_Element.TrueDamage);
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
