using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleBuff {
    protected int turnCount;
    protected BattleBuff(int turn){
        turnCount = turn+1;
    }

    public abstract S_BattleActorStatus EffectedBuff(S_BattleActorStatus status,BattleActorAction action);

    public bool CheckContinueBuff(){
        turnCount--;
        if(turnCount == 0){
            return false;
        }

        return true;
    }
}
