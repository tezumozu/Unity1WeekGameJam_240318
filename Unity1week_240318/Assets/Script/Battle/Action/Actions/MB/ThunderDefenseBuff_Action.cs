using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDefenseBuff_Action : BattleActorAction{

    public ThunderDefenseBuff_Action():base(E_ActionType.ThunderDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.DefenseUP , 3},
            {E_Buff.ThunderResistanceUP , 3}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
