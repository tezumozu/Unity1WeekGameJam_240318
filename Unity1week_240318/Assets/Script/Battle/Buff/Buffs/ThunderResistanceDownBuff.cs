using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderResistanceDownBuff : BattleBuff{
    public ThunderResistanceDownBuff(int turn):base(E_Buff.ThunderResistanceDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.ThunderResistanceRate = status.ThunderResistanceRate / 1.5f;
        return status;
    }
}
