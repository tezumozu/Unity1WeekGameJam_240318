using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPStyle : EvoStyle{


    public override S_BattleActorStatus GetStatus(S_SlimeTrainingData data){

        var result = base.GetStatus(data);

        result.Image = E_MonsterImage.M_Slime;

        result.Attack = (int)((float)data.Attack * 1.25f);
        result.Defense = (int)((float)data.Defense * 1.25f);
        result.Speed = (int)((float)data.Speed * 1.25f);

        return result;
    }


    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var result = new List<E_ActionType>();
        result.Add(E_ActionType.Cometto);

        var list = base.GetLearningSkill(data);
        result.AddRange(list);
        return result;
    }
}
