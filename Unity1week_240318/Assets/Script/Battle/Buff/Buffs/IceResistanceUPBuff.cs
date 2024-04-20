using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceResistanceUPBuff : BattleBuff{
    public IceResistanceUPBuff(int turn):base(E_Buff.IceResistanceUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.IceResistanceRate = status.IceResistanceRate * 1.5f;
        return status;
    }
}
