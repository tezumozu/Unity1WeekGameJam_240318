using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameResistanceDownBuff : BattleBuff{
    public FlameResistanceDownBuff(int turn):base(E_Buff.FlameResistanceDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        status.FlameResistanceRate = status.FlameResistanceRate / 1.5f;
        return status;
    }
}
