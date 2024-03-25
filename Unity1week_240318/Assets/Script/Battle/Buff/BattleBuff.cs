using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleBuff {
    protected int turnCount;
    public readonly BuffData BuffData;

    protected BattleBuff(E_Buff type,int turn){

        //パスを生成
        var fileName = "BattleScene/BuffDataList";
        //読み込む
        var dataList = Resources.Load<BuffDataList>(fileName);
        foreach(var data in dataList.DataList){
            if (data.BuffType == type){
                BuffData = data;
            }
        }

        Resources.UnloadUnusedAssets();

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
