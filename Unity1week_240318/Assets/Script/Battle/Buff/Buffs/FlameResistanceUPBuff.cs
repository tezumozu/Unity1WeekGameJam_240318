using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameResistanceUPBuff : BattleBuff{
    public FlameResistanceUPBuff(int turn):base(E_Buff.FlameResistanceUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.FlameResistanceRate = status.FlameResistanceRate * 1.5f;
        return status;
    }
}
