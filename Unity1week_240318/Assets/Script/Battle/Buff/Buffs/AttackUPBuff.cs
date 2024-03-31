using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUPBuff : BattleBuff{
    public AttackUPBuff(int turn):base(E_Buff.AttackUP,turn){

    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.Attack = (int)((float)status.Attack * 1.5f);
        return status;
    }
}
