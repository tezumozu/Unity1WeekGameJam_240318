using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalUPBuff : BattleBuff{
    public CriticalUPBuff(int turn):base(turn){

    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){
        status.CriticalCorrection = 4.0f;
        return status;
    }
}
