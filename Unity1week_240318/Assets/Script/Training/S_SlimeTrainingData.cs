using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_SlimeTrainingData{
    public int Level;
    public int CurrentStateExp;
    public int StaminaLevel;
    public int CurrentStateStamina;
    public int HPLevel;
    public int MPLevel;
    public int AttackLevel;
    public int DefenseLevel;
    public int SpeedLevel;
    public int SkillPoint;

    public S_SlimeTrainingData(int level){
        Level = level;
        CurrentStateExp = 0;
        StaminaLevel = 1;
        CurrentStateStamina = 3;
        HPLevel = 1;
        MPLevel = 1;
        AttackLevel = 1;
        DefenseLevel = 1;
        SpeedLevel = 1;
        SkillPoint = (level-1) * 2;
    }
} 

