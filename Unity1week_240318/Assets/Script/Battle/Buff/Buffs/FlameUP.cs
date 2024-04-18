using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameUP : BattleBuff{
    public FlameUP(int turn):base(E_Buff.FlameUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        if(action.ActionData.Element == E_Element.Flame){
            status.Attack = (int)((float)status.Attack * 1.5f);
        }
        return status;
    }
}
