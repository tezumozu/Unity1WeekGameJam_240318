using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDown : BattleBuff{
    public IceDown(int turn):base(E_Buff.IceDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Element == E_Element.Ice){
            status.Attack = (int)((float)status.Attack / 1.5f);
        }
        return status;
    }
}
