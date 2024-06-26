using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBuff_Action : BattleActorAction{

    public ResetBuff_Action():base(E_ActionType.ResetBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return diffender.ClearBuff( E_BuffType.Buff );

        yield return diffender.ClearEffect( E_BuffType.Buff );
    }
}
