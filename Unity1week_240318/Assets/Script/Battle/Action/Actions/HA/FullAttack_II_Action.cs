using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAttack_II_Action : BattleActorAction{

    public FullAttack_II_Action():base(E_ActionType.FullSwing_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        //次のターン反動で動けなくする
        IsNextAction = true;
        NextAction = E_ActionType.Wait;
    }
}
