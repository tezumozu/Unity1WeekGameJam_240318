using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAttack_I_Action : BattleActorAction{

    public CureAttack_I_Action():base(E_ActionType.CureAttack_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var damage = base.UseAction(effectedStatus,attacker,diffender);
        yield return damage;

        //バフを付与
        yield return attacker.AppliyHeel( (int)damage.Current / 3 );
    }
}
