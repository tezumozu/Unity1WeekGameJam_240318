using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStyle : EvoStyle{


    public override S_BattleActorStatus GetStatus(S_SlimeTrainingData data){

        var result = base.GetStatus(data);

        result.Image = E_MonsterImage.A_Slime;

        result.Attack = (int)((float)data.Attack * 1.25f);

        if(data.AttackLevel >= 50){
            result.HP = (int)((float)data.HP * 1.5f);
        }else{
            result.HP = (int)((float)data.HP * 1.25f);
        }

        return result;
    }

    
    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var list = base.GetLearningSkill(data);
        return list;
    }
}
