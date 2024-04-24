using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle_Action : BattleActorAction{

    public Tackle_Action():base(E_ActionType.Tackle){
    }

    protected override int CalculateAttackPoint(S_BattleActorStatus effectedStatus){
        Debug.Log("Difence : " + (int)((float)effectedStatus.Defense * (float)ActionData.Power * (float)effectedStatus.Level));
        return (int)((float)effectedStatus.Defense * (float)ActionData.Power * (float)effectedStatus.Level) ;
    }
}
