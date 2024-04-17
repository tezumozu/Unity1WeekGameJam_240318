using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense_Action : BattleActorAction{

    public Defense_Action():base(E_ActionType.Defense){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //防御状態を表すバフを付与
        yield return attacker.AppliyBuff( E_Buff.Defense ,1 );
    }
}
