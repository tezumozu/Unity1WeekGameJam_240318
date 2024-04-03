using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour{
    //データ共有用
    private static List<E_ActionType> skillList;
    private static S_BattleActorStatus BattleStatus;

    void Start(){
        //初期ステータスをロードする

        //初期データを読み込む
        //パスを生成
        var fileName = "BattleScene/PlayerInitData";
        //読み込む
        var InitData = Resources.Load<EnemyData>(fileName);

        if(InitData is null){
            Debug.Log("Load error! : PlayerData.GetPlayerSkill");
        }

        //初期ステータスを取得 
        BattleStatus = InitData.EnemyStatus;

        skillList = new List<E_ActionType>();


        //データの更新を監視


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

                //ステータスを取得 
                BattleStatus = InitData.EnemyStatus;

                skillList = new List<E_ActionType>();

                //スキルリストを取得
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

                //スキルリストを取得
                skillList = new List<E_ActionType>();

                //スキルリストを取得
                foreach(var item in InitData.SkillList){
                    skillList.Add(item.Skill);
                }
            }


            return BattleStatus;    
        }
    }
}
