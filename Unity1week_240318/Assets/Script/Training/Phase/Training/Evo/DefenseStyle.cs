using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseStyle : EvoStyle{

    
    public override S_BattleActorStatus GetStatus(S_SlimeTrainingData data){

        var result = base.GetStatus(data);

        result.Image = E_MonsterImage.B_Slime;

        result.Defense = (int)((float)data.Defense * 1.5f);

        return result;
    }


    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var list = base.GetLearningSkill(data);
        return list;
    }
}
