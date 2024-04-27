using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareStyle : EvoStyle{


    public override S_BattleActorStatus GetStatus(S_SlimeTrainingData data){

        var result = base.GetStatus(data);

        result.Image = E_MonsterImage.Rare_Slime;
        result.HP = (int)((float)data.HP * 1.5f);
        result.MP = (int)((float)data.MP * 1.5f);
        result.Attack = (int)((float)data.Attack * 1.5f);
        result.Defense = (int)((float)data.Defense * 1.5f);
        result.Speed = (int)((float)data.Speed * 1.5f);
        result.CriticalCorrection = 2.0f;

        return result;

    }


    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var result = new List<E_ActionType>();
        result.Add(E_ActionType.AllBuff);
        result.Add(E_ActionType.CriticalTrueAttack);
        result.Add(E_ActionType.StatusGuard);

        var list = new List<E_ActionType>();

        //HMの判定
        //パスを生成
        var fileName = "TrainingScene/LreaningData/HM";
        //読み込む
        var LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );


        //HAの判定
        //パスを生成
        fileName = "TrainingScene/LreaningData/HA";
        //読み込む
        LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );


        //HBの判定
        //パスを生成
        fileName = "TrainingScene/LreaningData/HB";
        //読み込む
        LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );


        //HSの判定
        //パスを生成
        fileName = "TrainingScene/LreaningData/HS";
        //読み込む
        LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );


        //MAの判定
        //パスを生成
        fileName = "TrainingScene/LreaningData/MA";
        //読み込む
        LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );

        //MBの判定
        //パスを生成
        fileName = "TrainingScene/LreaningData/MB";
        //読み込む
        LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );


        //MSの判定
        //パスを生成
        fileName = "TrainingScene/LreaningData/MS";
        //読み込む
        LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        result.AddRange( LreaningData.CheckLreaning( data.Level ) );


        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

        return result;
    }
}
