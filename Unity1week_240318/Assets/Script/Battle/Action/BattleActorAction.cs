using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleActorAction {
    
    public readonly ActionData ActionData;
    public bool IsNextAction {get; protected set;}
    public E_ActionType NextAction {get; protected set;}
    protected bool isCritical = false;

    protected BattleActorAction(E_ActionType type){
        //パラメータ初期化のため毎回読み込み

        //パスを生成
        var fileName = "BattleScene/SkillDataList";
        //読み込む
        var dataList = Resources.Load<ActionDataList>(fileName);
        foreach(var data in dataList.DataList){
            if (data.type == type){
                ActionData = data;
            }
        }

        IsNextAction = false;
        NextAction = E_ActionType.Attack;

        Resources.UnloadUnusedAssets();
    }

    public abstract IEnumerator UseAction(S_BattleActorStatus effectedStatus,I_DamageApplicable attacker,I_DamageApplicable diffender);


    public virtual bool CheckCritical(S_BattleActorStatus effectedStatus){
        if(effectedStatus.CriticalCorrection * ActionData.CriticalRate > Random.Range( 0.0f , 1.0f )){
            Debug.Log(effectedStatus.CriticalCorrection * ActionData.CriticalRate);
            isCritical = true;
        }else{
            isCritical = false;
        }
        return isCritical;
    }


    public virtual bool checkSuccess(BattleActor Player,BattleActor Enemy){
        if(ActionData.SuccessRate < Random.Range(0.0f,1.0f)){
            return false;
        }
        
        return true;
    }

    public virtual S_BattleActorStatus CheckBonus(S_BattleActorStatus status , BattleActor Player,BattleActor Enemy){
        return status;
    }
}
