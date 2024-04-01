using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_BattleDate{
    public int TakeTurn;
    public int WinCount;
    public BattleActor Player;
    public BattleActor Enemy;

    public S_BattleDate(int WinCount, int TakeTurn,BattleActor Player,BattleActor Enemy){
        this.WinCount = WinCount;
        this.TakeTurn = TakeTurn;
        this.Player = Player;
        this.Enemy = Enemy;
    }
}
