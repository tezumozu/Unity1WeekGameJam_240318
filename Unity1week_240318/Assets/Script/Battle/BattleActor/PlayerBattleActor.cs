using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleActor : BattleActor{
    public PlayerBattleActor():base(PlayerData.GetPlayerStatus){
        //ステータスの生成
    }
}
