using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash_Action : BattleActorAction{

    public Slash_Action():base(E_ActionType.Slash){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.DefenseDown , 5 );
    }
}
