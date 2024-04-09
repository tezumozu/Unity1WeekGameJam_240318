using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using UniRx;

public class PlayerData : MonoBehaviour{
    //データ共有用
    private static List<E_ActionType> skillList;
    private static S_BattleActorStatus BattleStatus;

    [Inject]
    SlimeTrainingManager trainingManager;

    void Start(){
        //データの更新を監視
        trainingManager.DefinitionStatusAsync
        .Subscribe((status) => {
            BattleStatus = status;
        })
        .AddTo(this);


        trainingManager.DefinitioSkillAsync
        .Subscribe((list) => {
            skillList = list;
        })
        .AddTo(this);
    }

    public static List<E_ActionType> GetPlayerSkillList{
        //もしデータが入っていなかったら（テスト用）

        get{
            if(skillList is null){
                //初期データを読み込む
                //パスを生成
                //var fileName = "BattleScene/PlayerInitData";
                var fileName = "BattleScene/PlayerTestData";
                //読み込む
                var InitData = Resources.Load<EnemyData>(fileName);

                if(InitData is null){
                    Debug.Log("Load error! : PlayerData.GetPlayerSkill");
                }

                //スキルリストを取得
                skillList = new List<E_ActionType>();
                foreach(var item in InitData.SkillList){
                    skillList.Add(item.Skill);
                }
            }


            return new List<E_ActionType>(skillList);
        }
    }

    public static S_BattleActorStatus GetPlayerStatus{
        get{
            if(BattleStatus.HP == 0){
                //初期データを読み込む
                    //パスを生成
                //var fileName = "BattleScene/PlayerInitData";
                var fileName = "BattleScene/PlayerTestData";
                //読み込む
                var InitData = Resources.Load<EnemyData>(fileName);

                if(InitData is null){
                    Debug.Log("Load error! : PlayerData.GetPlayerSkill");
                }

                //ステータスを取得 
                BattleStatus = InitData.EnemyStatus;
            }


            return BattleStatus;    
        }
    }
}
