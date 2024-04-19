using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndThunderBuff_Action : BattleActorAction{

    public DefenseAndThunderBuff_Action():base(E_ActionType.DefenseAndThunderBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 1},
            {E_Buff.ThunderUP , 3}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
