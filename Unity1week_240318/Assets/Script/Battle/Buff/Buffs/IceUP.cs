using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceUP : BattleBuff{
    public IceUP(int turn):base(E_Buff.IceUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Element == E_Element.Ice){
            status.Attack = (int)((float)status.Attack * 1.5f);
        }
        return status;
    }
}
