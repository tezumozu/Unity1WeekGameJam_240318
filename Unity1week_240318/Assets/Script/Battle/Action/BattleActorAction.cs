using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleActorAction {
    
    public readonly ActionData ActionData;
    public BattleActorAction CurrentAction {get; protected set;}

    protected BattleActorAction(E_ActionType type){
        //パラメータ書き換え防止

        //パスを生成
        var fileName = "BattleScene/DataList";
        //読み込む
        var dataList = Resources.Load<ActionDataList>(fileName);
        foreach(var data in dataList.DataList){
            if (data.type == E_ActionType.Attack){
                ActionData = data;
            }
        }
    }

    public abstract ActionResult UseAction(BattleActor attacker,I_DamageApplicable diffender);
}
