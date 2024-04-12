using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_SlimeTrainingData{
    public int Level;
    public int CurrentExp;
    public int MaxExp;
    public int HPLevel;
    public int HP;
    public int MPLevel;
    public int MP;
    public int AttackLevel;
    public int Attack;
    public int DefenseLevel;
    public int Defense;
    public int SpeedLevel;
    public int Speed;
    public int SkillPoint;

    public S_SlimeTrainingData(S_BattleActorStatus status,StatusTable table){
        Level = status.Level;
        CurrentExp = 0;
        MaxExp = table.NeedExp[0];
        HPLevel = 1;
        MPLevel = 1;
        AttackLevel = 1;
        DefenseLevel = 1;
        SpeedLevel = 1;
        SkillPoint = (Level-1) * 3 + 3;

        HP = status.HP;
        MP = status.MP;
        Attack = status.Attack;
        Defense = status.Defense;
        Speed = status.Speed;
    }
} 

