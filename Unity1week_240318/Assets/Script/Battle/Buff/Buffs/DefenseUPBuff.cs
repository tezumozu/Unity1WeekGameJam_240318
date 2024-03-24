using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUPBuff : BattleBuff{
    public DefenseUPBuff(int turn):base(turn){

    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        status.Defense = (int)(status.Defense * 1.5f);
        return status;
    }
}
