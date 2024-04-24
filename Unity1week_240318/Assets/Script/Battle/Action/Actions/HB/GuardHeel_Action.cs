using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHeel_Action : BattleActorAction{

    public GuardHeel_Action():base(E_ActionType.GuardHeel){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.Defense , 1 );
        //バフを付与
        yield return attacker.AppliyHeel( attacker.GetMaxStatus.HP / 2  );
    }
}
