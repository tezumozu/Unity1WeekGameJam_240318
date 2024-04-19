using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndIceBuff_Action : BattleActorAction{

    public DefenseAndIceBuff_Action():base(E_ActionType.DefenseAndIceBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 1},
            {E_Buff.IceUP , 3}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
