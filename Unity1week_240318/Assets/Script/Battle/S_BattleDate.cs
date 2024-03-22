using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_BattleDate{
    public int WinCount;
    public PlayerBattleActor Player;
    public EnemyBattleActor Enemy;

    public S_BattleDate(int WinCount,PlayerBattleActor Player,EnemyBattleActor Enemy){
        this.WinCount = WinCount;
        this.Player = Player;
        this.Enemy = Enemy;
    }
}
