using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleActor : BattleActor{

    public EnemyBattleActor(E_EnemyType type):base(new S_BattleActorStatus(10,10,10,10,10)){
        //ステータスの生成
    }
}
