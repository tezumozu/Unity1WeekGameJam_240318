using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackDownBuff : BattleBuff{
    public NormalAttackDownBuff(int turn):base(E_Buff.NormalAttackDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.AttackType == E_AttackType.Attack){
            status.Attack = (int)((float)status.Attack / 1.5f);
        }

        return status;
    }

}
