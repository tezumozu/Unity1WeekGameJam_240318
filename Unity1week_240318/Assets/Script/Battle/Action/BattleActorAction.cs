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
            if (data.Type == type){
                ActionData = data.Clone();
            }
        }

        IsNextAction = false;
        NextAction = E_ActionType.Attack;

        Resources.UnloadUnusedAssets();
    }


    //パラメータのみ違う技用
    public virtual IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //攻撃側の攻撃力を計算
        int attackPoint = (int)((float)CalculateAttackPoint(effectedStatus) * getDamageRamd());

        //クリティカル判定
        if(isCritical){
            attackPoint = (int)((float)attackPoint * 1.5f);
        }

        //ダメージ計算の終了待ちをする
        var damageCalculate = diffender.AppliyDamage(attackPoint,ActionData.Element);
        yield return damageCalculate;
        
        int result = (int)damageCalculate.Current;

        yield return result;
    }


    public virtual bool CheckCritical(S_BattleActorStatus effectedStatus){
        if(effectedStatus.CriticalCorrection * ActionData.CriticalRate > Random.Range( 0.0f , 1.0f )){
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

    protected int CalculateAttackPoint(S_BattleActorStatus effectedStatus){
        return (int)((float)effectedStatus.Attack * (float)ActionData.Power * (float)effectedStatus.Level) ;
    }

    protected float getDamageRamd (){
        return UnityEngine.Random.Range( 0.9f , 1.1f );
    }
}
