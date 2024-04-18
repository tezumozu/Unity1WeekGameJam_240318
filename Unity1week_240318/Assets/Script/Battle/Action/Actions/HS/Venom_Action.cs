using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venom_Action : BattleActorAction{

    public Venom_Action():base(E_ActionType.Venom){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //状態異常付与
        yield return diffender.AppliyEffect( E_AfterStatusEffect.Venom );
    }
}
