using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSoft_Action : BattleActorAction{

    public ToSoft_Action():base(E_ActionType.ToSoft){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        yield return base.UseAction(effectedStatus,attacker,diffender);

        //バフを付与
        var buffList = new List<E_Buff>(){
            E_Buff.FlameResistanceUP, 
            E_Buff.IceResistanceUP,
            E_Buff.ThunderResistanceUP,
            E_Buff.DefenseUP
        };

        yield return diffender.ClearBuff( buffList , E_BuffType.Debuff );

        var buffDic = new Dictionary<E_Buff, int>(){
            { E_Buff.FlameResistanceDown , 4 } ,
            { E_Buff.IceResistanceDown , 4 } ,
            { E_Buff.ThunderResistanceDown , 4 }
        };

        //バフを付与
        yield return diffender.AppliyDeBuff( buffDic );
    }
}
