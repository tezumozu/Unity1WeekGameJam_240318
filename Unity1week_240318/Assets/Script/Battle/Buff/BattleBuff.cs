using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleBuff {
    public int TurnCount {get; protected set;}
    public readonly BuffData BuffData;

    protected BattleBuff(E_Buff type,int turn){

        //パスを生成
        var fileName = "BattleScene/Buff/BuffDataList";
        //読み込む
        var dataList = Resources.Load<BuffDataList>(fileName);
        foreach(var data in dataList.DataList){
            if (data.BuffType == type){
                BuffData = data;
            }
        }

        Resources.UnloadUnusedAssets();

        TurnCount = turn+1;
    }

    public virtual S_BattleActorStatus EffectedBuff(S_BattleActorStatus status,BattleActorAction action){
        return EffectedBuff(status);
    }
    
    public virtual S_BattleActorStatus EffectedBuff(S_BattleActorStatus status){
        return status;
    }

    public bool CheckContinueBuff(){
        TurnCount--;
        if(TurnCount == 0){
            return false;
        }

        return true;
    }
}
