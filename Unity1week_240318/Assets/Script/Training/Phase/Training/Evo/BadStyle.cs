
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadStyle : EvoStyle{

    private S_BattleActorStatus result;
    private StatusTable statusTable;

    public BadStyle(){

        //ステータステーブルを取得
        //パスを生成
        var fileName = "TrainingScene/StatusTableData";
        //読み込む
        statusTable = Resources.Load<StatusTable>(fileName);

        if(statusTable is null){
            Debug.Log("Load error! : PlayerData.GetPlayerSkill");
        }

        //初期データを読み込む
        //パスを生成
        fileName = "BattleScene/PlayerInitData";
        //読み込む
        result = Resources.Load<EnemyData>(fileName).EnemyStatus;

        if(result.Level == 0){
            Debug.Log("Load error! : PlayerData.GetPlayerSkill");
        }
    }


    public override S_BattleActorStatus GetStatus(S_SlimeTrainingData data){
        

        result.Image = E_MonsterImage.Bad_Slime;
        result.Level = 60;
        int skillPoint = (result.Level - 1) * 3;

        //ランダムにステータスを割り振る
            //ランダムにステータス割り振る
        int[] randList = new int[6];
        int[] randSkillPoint = new int[5];

        randList[0] = 0;
        randList[5] = skillPoint;
        for(int i = 1; i < 5; i++){
            randList[i] = UnityEngine.Random.Range(0,skillPoint);
        }

        Array.Sort(randList);

        for(int i = 0; i < 5; i++){
            randSkillPoint[i] = randList[i+1] - randList[i];
        }
        

            //実数値に変換
        result.HP += (randSkillPoint[0] + data.HPLevel-1) * statusTable.StatusUpHPGrow + ( result.Level - 1 ) * statusTable.LevelUpHPGrow;

        result.MP += (randSkillPoint[1] + data.MPLevel-1) * statusTable.StatusUpMPGrow + ( result.Level - 1 ) * statusTable.LevelUpMPGrow;

        result.Attack += (randSkillPoint[2] + data.AttackLevel-1) * statusTable.StatusUpAttackGrow + ( result.Level - 1 ) * statusTable.LevelUpAttackGrow;

        result.Defense += (randSkillPoint[3] + data.DefenseLevel-1) * statusTable.StatusUpDefenseGrow + ( result.Level - 1 ) * statusTable.LevelUpDefenseGrow;

        result.Speed += (randSkillPoint[4] + data.SpeedLevel-1) * statusTable.StatusUpSpeedGrow + ( result.Level - 1 ) * statusTable.LevelUpSpeedGrow;

        return result;
    }


    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var result = new List<E_ActionType>();
        result.Add(E_ActionType.SelfDestruction);
        result.Add(E_ActionType.RecoilBuff);

        var list = base.GetLearningSkill(data);
        result.AddRange(list);

        return result;
    }
}
