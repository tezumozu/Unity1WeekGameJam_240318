using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_BattleActorStatus{
    public int HP;
    public int MP;
    public int Attack;
    public int Defense;
    public int Speed;

    public S_BattleActorStatus(int h,int m,int a,int d,int s){
        HP = h;
        MP = m;
        Attack = a;
        Defense = d;
        Speed = s;
    }
} 
