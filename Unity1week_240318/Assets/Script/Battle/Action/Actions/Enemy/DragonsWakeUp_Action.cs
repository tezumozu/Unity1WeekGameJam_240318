using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsWakeUp_Action : BattleActorAction{

    public DragonsWakeUp_Action():base(E_ActionType.DragonsWakeUp){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.AttackUP , 5},
            {E_Buff.FlameUP , 5}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
