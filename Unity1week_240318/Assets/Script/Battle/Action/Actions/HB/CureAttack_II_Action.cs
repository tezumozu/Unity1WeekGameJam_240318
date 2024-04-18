using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAttack_II_Action : BattleActorAction{

    public CureAttack_II_Action():base(E_ActionType.CureAttack_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var damage = base.UseAction(effectedStatus,attacker,diffender);
        yield return damage;

        //バフを付与
        yield return attacker.AppliyHeel( (int)damage.Current / 2  );
    }
}
