using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EvoStyle : I_LearningSkillCheckable{


    public virtual S_BattleActorStatus GetStatus(S_SlimeTrainingData data){
        var result = new S_BattleActorStatus();
        result.Level = data.Level;
        result.HP = data.HP;
        result.MP = data.MP;
        result.Attack = data.Attack;
        result.Defense = data.Defense;
        result.Speed = data.Speed;

        return result;
    }


    public virtual List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){

        var list = new List<E_ActionType>();

        //HMの判定
        //パスを生成
        var fileName = "TrainingScene/LreaningData/HM";
        //読み込む
        var LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

        if(LreaningData is null){
            Debug.Log("Load error! : PlayerData.LreaningData");
        }

        list.AddRange(LreaningData.CheckLreaning(data.HPLevel + data.MPLevel));



        if(data.HP < data.MP){
            //MAの判定
            //パスを生成
            fileName = "TrainingScene/LreaningData/MA";
            //読み込む
            LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

            if(LreaningData is null){
                Debug.Log("Load error! : PlayerData.LreaningData");
            }

            list.AddRange(LreaningData.CheckLreaning(data.AttackLevel));


            //MBの判定
            //パスを生成
            fileName = "TrainingScene/LreaningData/MB";
            //読み込む
            LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

            if(LreaningData is null){
                Debug.Log("Load error! : PlayerData.LreaningData");
            }

            list.AddRange(LreaningData.CheckLreaning(data.DefenseLevel));


            //MSの判定
            //パスを生成
            fileName = "TrainingScene/LreaningData/MS";
            //読み込む
            LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

            if(LreaningData is null){
                Debug.Log("Load error! : PlayerData.LreaningData");
            }

            list.AddRange(LreaningData.CheckLreaning(data.SpeedLevel));
            
        }else{

            //HAの判定
            //パスを生成
            fileName = "TrainingScene/LreaningData/HA";
            //読み込む
            LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

            if(LreaningData is null){
                Debug.Log("Load error! : PlayerData.LreaningData");
            }

            list.AddRange(LreaningData.CheckLreaning(data.AttackLevel));


            //HBの判定
            //パスを生成
            fileName = "TrainingScene/LreaningData/HB";
            //読み込む
            LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

            if(LreaningData is null){
                Debug.Log("Load error! : PlayerData.LreaningData");
            }

            list.AddRange(LreaningData.CheckLreaning(data.DefenseLevel));


            //HSの判定
            //パスを生成
            fileName = "TrainingScene/LreaningData/HS";
            //読み込む
            LreaningData = Resources.Load<SkillLreaningChecker>(fileName);

            if(LreaningData is null){
                Debug.Log("Load error! : PlayerData.LreaningData");
            }

            list.AddRange(LreaningData.CheckLreaning(data.SpeedLevel));

        }

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

        return list;
    }


}
