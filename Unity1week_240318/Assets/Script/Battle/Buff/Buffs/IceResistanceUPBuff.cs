using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceResistanceUPBuff : BattleBuff{
    public IceResistanceUPBuff(int turn):base(E_Buff.IceResistanceUP,turn){
    }

    public override S_BattleActorStatus EffectedBuff (S_BattleActorStatus status){

        status.ElementResistanceRateDic[E_Element.Ice] = status.ElementResistanceRateDic[E_Element.Ice] * 1.5f;
        return status;
    }
}
