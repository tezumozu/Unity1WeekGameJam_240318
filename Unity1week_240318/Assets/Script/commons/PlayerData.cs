using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData{

    //共有用
    private static List<E_ActionType> skillList;
    private static S_BattleActorStatus BattleStatus = new S_BattleActorStatus(10,10,10,10,10);

    public static List<E_ActionType> GetSkillList{
        get{return new List<E_ActionType>(skillList);}
    }

    public static S_BattleActorStatus GetPlayerStatus{
        get{return BattleStatus;}
    }
}
