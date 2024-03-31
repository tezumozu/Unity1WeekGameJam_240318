using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUPBuff : BattleBuff{
    public MagicUPBuff(int turn):base(E_Buff.MagicUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.AttackType == E_AttackType.Magic){
            status.Attack = (int)((float)status.Attack * 1.5f);
        }
        return status;
    }
}
