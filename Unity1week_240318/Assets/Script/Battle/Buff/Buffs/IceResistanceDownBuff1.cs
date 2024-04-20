using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceResistanceDownBuff : BattleBuff{
    public IceResistanceDownBuff(int turn):base(E_Buff.IceResistanceDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){
        status.IceResistanceRate = status.IceResistanceRate / 1.5f;
        return status;
    }
}
