using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDebuff_Action : BattleActorAction{

    public DefenseDebuff_Action():base(E_ActionType.DefenseDebuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //防御状態を表すバフを付与
        yield return diffender.AppliyDeBuff( E_Buff.DefenseDown ,4 );
    }
}
