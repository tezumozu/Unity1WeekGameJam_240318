using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPDrain_I_Action : BattleActorAction{

    public MPDrain_I_Action():base(E_ActionType.MPDrain_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var damage = base.UseAction(effectedStatus,attacker,diffender);
        yield return damage;

        //MP回復
        yield return attacker.AppliyMPHeel( (int)damage.Current / 10 );
    }
}
