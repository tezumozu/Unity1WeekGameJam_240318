using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCrush_NEXT_Action : BattleActorAction{

    public ArmCrush_NEXT_Action():base(E_ActionType.ArmCrush_NEXT){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        //次の行動を自由にする
        IsNextAction = false;
    }
}
