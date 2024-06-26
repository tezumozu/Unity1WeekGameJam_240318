using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDefenseBuff_Action : BattleActorAction{

    public IceDefenseBuff_Action():base(E_ActionType.IceDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.DefenseUP , 3},
            {E_Buff.IceResistanceUP , 3},
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
