using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackUPBuff : BattleBuff{
    public NormalAttackUPBuff(int turn):base(E_Buff.NormalAttackUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.AttackType == E_AttackType.Attack){
            status.Attack = (int)((float)status.Attack * 1.5f);
        }
        return status;
    }
}
