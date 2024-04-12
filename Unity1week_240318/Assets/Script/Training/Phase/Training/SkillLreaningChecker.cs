using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillLreaningChecker", menuName = "ScriptableObjects/SkillLreaningChecker", order = 0)]
public class SkillLreaningChecker : ScriptableObject {

    [SerializeField]
    List<LreaningData> dataList;


    public List<E_ActionType> CheckLreaning(int statusLevel){

        var result = new List<E_ActionType>();

        foreach (var data in dataList){
            if(data.Level > statusLevel) break;

            result.Add(data.Skill);

        }

        return result;
    }
}



[Serializable]
public class LreaningData{
    [SerializeField]
    public int Level;

    [SerializeField]
    public E_ActionType Skill;
}
