using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderResistanceDownBuff : BattleBuff{
    public ThunderResistanceDownBuff(int turn):base(E_Buff.ThunderResistanceDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        status.ElementResistanceRateDic[E_Element.Thunder] = status.ElementResistanceRateDic[E_Element.Thunder] * 1.5f;
        return status;
    }
}
