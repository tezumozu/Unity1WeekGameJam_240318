using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAndDefenseBuff_Action : BattleActorAction{

    public DefenseAndDefenseBuff_Action():base(E_ActionType.DefenseAndDefenseBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 3},
            {E_Buff.DefenseUP , 3}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
