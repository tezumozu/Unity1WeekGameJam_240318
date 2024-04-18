using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff_Action : BattleActorAction{

    public AttackBuff_Action():base(E_ActionType.AttackBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //防御状態を表すバフを付与
        yield return attacker.AppliyBuff( E_Buff.AttackUP ,5 );
    }
}
