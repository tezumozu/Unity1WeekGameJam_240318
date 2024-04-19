using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPAndMPDrain_Action : BattleActorAction{

    public HPAndMPDrain_Action():base(E_ActionType.HPAndMPDrain){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var damage = base.UseAction(effectedStatus,attacker,diffender);
        yield return damage;

        yield return attacker.AppliyHeel( (int)damage.Current * 5 / 10 );
        yield return attacker.AppliyMPHeel( (int)damage.Current * 3 / 10 );
    }
}
