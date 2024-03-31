using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDownBuff : BattleBuff{
    public DefenseDownBuff(int turn):base(E_Buff.DefenseDown,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.Defense = (int)((float)status.Defense / 1.5f);
        return status;
    }
}
