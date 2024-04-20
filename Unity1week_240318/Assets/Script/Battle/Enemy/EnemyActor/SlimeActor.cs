using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class SlimeActor : BattleActor{

    private List<S_EnemySkillData> enemySkillList;
    private Dictionary<E_ActionType,bool> SPActionDic;


    public SlimeActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        
        //マネージャの取得
        statusUIManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorUIManager>();
        actorAnimManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorAnimManager>();
        
        //ステータス読み込み
        //パスを生成
        var fileName = "BattleScene/Enemy/Slime";
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

        SPActionDic = new Dictionary<E_ActionType,bool>();
        SPActionDic[E_ActionType.Anger] = true;
    }



    public override IEnumerator SetNextAction(){
        E_ActionType skillType = E_ActionType.Attack;

        //次の行動が決まっているか確認
        if(currentAction.IsNextAction){

            skillType = currentAction.NextAction;

        }else{
            //使用率に合わせてランダムに取得する
            float rand = UnityEngine.Random.Range( 0.0f , 1.0f );
            float rate = 0.0f;

            foreach(var skill in enemySkillList){

                rate += skill.UseRate;

                if(rate > rand){
                    skillType = skill.Skill;
                    break;
                }

            }

            //特別な行動をする場合
            switch ((float)currentStatus.HP / (float)maxStatus.HP){
                case float x when x < 0.5f :
                    if(SPActionDic[E_ActionType.Anger]){
                        skillType = E_ActionType.Anger;
                        SPActionDic[E_ActionType.Anger] = false;
                    }
                    break;
            }

        }

        currentAction = actionFactory.CreateAction(skillType);

        yield return null;
    }

}
