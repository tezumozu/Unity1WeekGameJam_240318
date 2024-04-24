using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAll_Action : BattleActorAction{

    public CureAll_Action():base(E_ActionType.CureAll){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //回復
        yield return CoroutineHander.OrderStartCoroutine(attacker.AppliyHeel( attacker.GetMaxStatus.HP * 3 /4 ));

        //状態異常回復
        yield return CoroutineHander.OrderStartCoroutine(attacker.ClearEffect( E_BuffType.Debuff ));
    }
}
