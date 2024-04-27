using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCrush_Action : BattleActorAction{

    public SwordCrush_Action():base(E_ActionType.SwordCrush){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        var ClearList = new List<E_Buff>(){
            E_Buff.AttackUP,
            E_Buff.NormalAttackUP
        };

        //バフを付与
        yield return diffender.ClearBuff( ClearList , E_BuffType.Debuff);

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.AttackDown , 4},
            {E_Buff.NormalAttackDown , 4}
        };

        //バフを付与
        yield return diffender.AppliyDeBuff( buffList );
    }
}
