using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EnemyBattleActor : BattleActor{

    private List<S_EnemySkillData> enemySkillList;


    public EnemyBattleActor(E_EnemyType type,I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        
        //マネージャの取得
        statusUIManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorUIManager>();
        actorAnimManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorAnimManager>();
        
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
        enemySkillList = enemyData.SkillList;

        //UI初期化
        //ステータスをセット
        statusUIManager.SetStatus(currentStatus,currentStatus);
        statusUIManager.SetSprite(currentStatus.Image);
        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);
        statusUIManager.SetBuffList(buffDic.Values);

        finishAnimDispose = actorAnimManager.FinishAnimAsync.Subscribe((type)=>{
            isFinishAnim = true;
        });

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();
    }



    public override IEnumerator SetNextAction(){
        currentAction = actionFactory.CreateAction(E_ActionType.Attack);

        //次の行動が決まっているか確認
        if(currentAction.IsNextAction){

            currentAction = actionFactory.CreateAction(currentAction.NextAction);

        }else{

            //使用率に合わせてランダムに取得する
            float rand = UnityEngine.Random.Range( 0.0f , 1.0f );
            float rate = 0.0f;

            foreach(var skill in enemySkillList){

                rate += skill.UseRate;

                if(rate < rand){
                    currentAction = actionFactory.CreateAction(skill.Skill);
                    break;
                }

            }

        }



        yield return null;
    }

}
