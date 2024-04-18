using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefense_Action : BattleActorAction{

    public AttackDefense_Action():base(E_ActionType.AttackDefense){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 1},
            {E_Buff.AttackUP , 3}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
