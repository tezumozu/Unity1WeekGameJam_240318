using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackUPBuff : BattleBuff{
    public NormalAttackUPBuff(int turn):base(E_Buff.NormalAttackUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Cost == 0){
            status.Attack = (int)(status.Attack * 2.0f);
        }
        return status;
    }
}
