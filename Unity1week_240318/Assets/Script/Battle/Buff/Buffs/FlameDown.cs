using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDown : BattleBuff{
    public FlameDown(int turn):base(E_Buff.FlameDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Element == E_Element.Flame){
            status.Attack = (int)((float)status.Attack / 1.5f);
        }
        return status;
    }
}
