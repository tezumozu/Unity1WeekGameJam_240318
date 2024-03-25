using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuff : BattleBuff{
    public DefenseBuff(int turn):base(E_Buff.Defense,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status,BattleActorAction action){

        status.Defense = (int)(status.Defense * 1.25f);
        return status;
    }
}