using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderResistanceUPBuff : BattleBuff{
    public ThunderResistanceUPBuff(int turn):base(E_Buff.ThunderResistanceUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.ThunderResistanceRate = status.ThunderResistanceRate * 1.5f;
        return status;
    }
}
