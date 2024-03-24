using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUPBuff : BattleBuff{
    public AttackUPBuff(int turn):base(turn){

    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status , BattleActorAction action){

        status.Attack = (int)(status.Attack * 1.5f);
        return status;
    }
}
