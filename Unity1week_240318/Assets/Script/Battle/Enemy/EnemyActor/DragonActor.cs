using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class DragonActor : BattleActor{

    private List<S_EnemySkillData> enemySkillList;
    private Dictionary<E_ActionType,bool> SPActionDic;


    public DragonActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        
        //マネージャの取得
        statusUIManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorUIManager>();
        actorAnimManager = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorAnimManager>();
        
        //ステータス読み込み
        //パスを生成
        var fileName = "BattleScene/Enemy/Dragon";
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
        SPActionDic[E_ActionType.DragonsWakeUp] = true;
        SPActionDic[E_ActionType.DragonsAnger] = true;
        SPActionDic[E_ActionType.ImperialWrath] = true;
        SPActionDic[E_ActionType.BlackMeteo] = true;
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
                case float x when x < 0.3f :
                    if(SPActionDic[E_ActionType.BlackMeteo]){
                        skillType = E_ActionType.BlackMeteo;
                        SPActionDic[E_ActionType.BlackMeteo] = false;
                    }
                    break;
                case float x when x < 0.5f :
                    if(SPActionDic[E_ActionType.ImperialWrath]){
                        skillType = E_ActionType.ImperialWrath;
                        SPActionDic[E_ActionType.ImperialWrath] = false;
                    }
                    break;
                case float x when x < 0.75f :
                    if(SPActionDic[E_ActionType.DragonsAnger]){
                        skillType = E_ActionType.DragonsAnger;
                        SPActionDic[E_ActionType.DragonsAnger] = false;
                    }
                    break;
                case float x when x <= 1.0f :
                    if(SPActionDic[E_ActionType.DragonsWakeUp]){
                        skillType = E_ActionType.DragonsWakeUp;
                        SPActionDic[E_ActionType.DragonsWakeUp] = false;
                    }
                    break;
            }

            //HP50%以下の時、SleepBiteはSlenceBiteになる
            if(skillType == E_ActionType.Attack && (float)currentStatus.HP / (float)maxStatus.HP < 0.5f){
                skillType = E_ActionType.Cometto;
            }

        }

        currentAction = actionFactory.CreateAction(skillType);

        yield return null;
    }

}
