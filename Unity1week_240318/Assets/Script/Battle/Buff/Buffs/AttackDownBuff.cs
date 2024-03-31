using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDownBuff : BattleBuff{
    public AttackDownBuff(int turn):base(E_Buff.AttackDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){
        status.Attack = (int)((float)status.Attack / 1.5f);
        return status;
    }
}
