using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_BattleDate{
    public int WinCount;
    public BattleActor Player;
    public BattleActor Enemy;

    public S_BattleDate(int WinCount,BattleActor Player,BattleActor Enemy){
        this.WinCount = WinCount;
        this.Player = Player;
        this.Enemy = Enemy;
    }
}
