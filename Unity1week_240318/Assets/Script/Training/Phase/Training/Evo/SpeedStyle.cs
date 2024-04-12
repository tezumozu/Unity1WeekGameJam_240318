using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStyle : EvoStyle{

    
    public override S_BattleActorStatus GetStatus(S_SlimeTrainingData data){

        var result = base.GetStatus(data);

        result.Image = E_MonsterImage.S_Slime;

        if(data.SpeedLevel >= 50){
            result.Attack = (int)((float)data.Attack * 1.5f);
            result.Defense = (int)((float)data.Defense * 1.5f);
        }else{
            result.Attack = (int)((float)data.Attack * 1.25f);
            result.Defense = (int)((float)data.Defense * 1.25f);
        }

        return result;
    }


    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var list = base.GetLearningSkill(data);
        return list;
    }
}
