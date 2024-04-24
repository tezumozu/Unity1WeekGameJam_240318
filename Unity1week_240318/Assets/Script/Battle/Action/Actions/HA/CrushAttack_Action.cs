using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushAttack_Action : BattleActorAction{

    public CrushAttack_Action():base(E_ActionType.CrushAttack){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        //バフを付与
        var buffList = new List<E_Buff>(){
            E_Buff.DefenseUP, 
            E_Buff.Defense
        };

        yield return diffender.ClearBuff( buffList , E_BuffType.Debuff );

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.DefenseDown , 4 );
    }
}
