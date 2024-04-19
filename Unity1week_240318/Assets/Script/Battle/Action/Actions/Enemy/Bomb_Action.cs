using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Action : BattleActorAction{

    public Bomb_Action():base(E_ActionType.Bomb){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        //バフを付与
        yield return diffender.AppliyEffect( E_AfterStatusEffect.TimeBomb );
    }
}
