using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction_Action : BattleActorAction{

    public SelfDestruction_Action():base(E_ActionType.SelfDestruction){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyDamage( attacker.GetMaxStatus.HP / 2 , E_Element.Constant);

        yield return base.UseAction(effectedStatus,attacker,diffender);
    }
}
