using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCrush_Action : BattleActorAction{

    public ArmCrush_Action():base(E_ActionType.ArmCrush){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 1},
            {E_Buff.AttackUP , 1}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );

        IsNextAction = true;
        NextAction = E_ActionType.ArmCrush_NEXT;
    }
}
