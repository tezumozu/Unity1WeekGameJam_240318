using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameResistanceUPBuff : BattleBuff{
    public FlameResistanceUPBuff(int turn):base(E_Buff.FlameResistanceUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.ElementResistanceRateDic[E_Element.Flame] = status.ElementResistanceRateDic[E_Element.Flame] * 1.5f;
        return status;
    }
}
