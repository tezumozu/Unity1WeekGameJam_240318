using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatustTable", menuName = "ScriptableObjects/StatustTable")]
public class StatusTable : ScriptableObject {
    public List<int> NeedExp;
    public List<int> SkillPointTable;

    public int LevelUpHPGrow;
    public int StatusUpHPGrow;

    public int LevelUpMPGrow;
    public int StatusUpMPGrow;

    public int LevelUpAttackGrow;
    public int StatusUpAttackGrow;

    public int LevelUpDefenseGrow;
    public int StatusUpDefenseGrow;

    public int LevelUpSpeedGrow;
    public int StatusUpSpeedGrow;

}
