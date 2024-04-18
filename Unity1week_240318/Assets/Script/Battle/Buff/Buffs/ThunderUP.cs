using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderUP : BattleBuff{
    public ThunderUP(int turn):base(E_Buff.ThunderUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Element == E_Element.Thunder){
            status.Attack = (int)((float)status.Attack * 1.5f);
        }
        return status;
    }
}
