using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCrush_Action : BattleActorAction{

    public SwordCrush_Action():base(E_ActionType.SwordCrush){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.AttackDown , 3},
            {E_Buff.NormalAttackDown , 3}
        };

        //バフを付与
        yield return diffender.AppliyDeBuff( buffList );
    }
}
