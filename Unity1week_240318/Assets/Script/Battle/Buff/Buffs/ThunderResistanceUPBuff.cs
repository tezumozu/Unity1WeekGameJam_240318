using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderResistanceUPBuff : BattleBuff{
    public ThunderResistanceUPBuff(int turn):base(turn){

    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        status.ElementResistanceRateDic[E_Element.Thunder] = status.ElementResistanceRateDic[E_Element.Thunder] / 1.5f;
        return status;
    }
}
