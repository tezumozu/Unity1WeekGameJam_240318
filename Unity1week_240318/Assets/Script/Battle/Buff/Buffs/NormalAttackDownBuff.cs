using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackDownBuff : BattleBuff{
    public NormalAttackDownBuff(int turn):base(turn){

    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Cost == 0){
            status.Attack = (int)(status.Attack / 1.5f);
        }

        return status;
    }
}
