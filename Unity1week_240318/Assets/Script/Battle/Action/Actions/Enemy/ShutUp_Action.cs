using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutUp_Action : BattleActorAction{

    public ShutUp_Action():base(E_ActionType.ShutUp){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 3},
            {E_Buff.DefenseUP , 3}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );

    }
}
