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

        return result;

    }


    public override List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data){
        var result = new List<E_ActionType>();
        result.Add(E_ActionType.AllBuff);
        result.Add(E_ActionType.CriticalTrueAttack);
        result.Add(E_ActionType.StatusGuard);

        var list = base.GetLearningSkill(data);
        result.AddRange(list);
        return result;
    }
}
