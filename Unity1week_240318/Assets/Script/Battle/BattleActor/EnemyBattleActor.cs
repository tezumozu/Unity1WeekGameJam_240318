using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleActor : BattleActor{

    protected static Dictionary<E_EnemyType,string> enemyNameDic;

    public EnemyBattleActor(E_EnemyType type,I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        
        //マネージャの取得
        statusUIManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorUIManager>();
        
        //ステータス読み込み
        //パスを生成
        var fileName = "BattleScene/Enemy/" +  type.ToString();
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

        //UI初期化
        //ステータスをセット
        statusUIManager.SetStatus(currentStatus,currentStatus);
        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);
        statusUIManager.SetBuffList(buffDic.Values);
    }



    public override IEnumerator SetNextAction(){
        currentActionType  = E_ActionType.Attack;
        yield return null;
    }

}
