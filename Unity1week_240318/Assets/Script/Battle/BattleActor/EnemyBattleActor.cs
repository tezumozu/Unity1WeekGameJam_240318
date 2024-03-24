using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleActor : BattleActor{

    public EnemyBattleActor(E_EnemyType type,I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        //ステータス読み込み
        //パスを生成
        var fileName = "BattleScene/Enemy" + type.ToString();
        //読み込む
        var enemyData = Resources.Load<EnemyData>(fileName);

        if(enemyData is null){
            Debug.Log("Load error! : EnemyBattleActor");
        }

        //ステータスを取得 
        maxStatus = enemyData.EnemyStatus;
        currentStatus = enemyData.EnemyStatus;

        //スキルリストを取得
        skillList = enemyData.SkillList;
    }


    public override List<string> CheckBeforeStatusEffect(){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> ActionBattleActor(E_ActionType type,I_DamageApplicable enemy){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> CheckAfterStatusEffect(){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> RefreshBattleActor(){
        var resultTextList = new List<string>();

        return resultTextList;
    }

    //ランダムで行動が必要な時用(混乱時など)
    protected List<string> ActionBattleActor(I_DamageApplicable enemy){
        var resultTextList = new List<string>();

        return resultTextList;
    }
}
