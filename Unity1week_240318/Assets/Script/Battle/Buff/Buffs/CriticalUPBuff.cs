using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalUPBuff : BattleBuff{
    public CriticalUPBuff(int turn):base(E_Buff.CriticalUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){
        status.CriticalCorrection = 4.0f;
        return status;
    }
}
