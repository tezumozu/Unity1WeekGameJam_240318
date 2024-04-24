using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDrain_Action : BattleActorAction{

    public MagicDrain_Action():base(E_ActionType.MagicDrain){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var attackPoint = diffender.GetCurrentEffectedStatus.Attack;

        //バフを付与
        yield return attacker.AppliyHeel( attackPoint );

        //バフを付与
        var buffList = new List<E_Buff>(){
            E_Buff.FlameUP, 
            E_Buff.IceUP,
            E_Buff.ThunderUP,
            E_Buff.MagicUP
        };

        yield return diffender.ClearBuff( buffList , E_BuffType.Debuff );

        var buffDic = new Dictionary<E_Buff, int>(){
            { E_Buff.FlameDown , 4 } ,
            { E_Buff.IceDown , 4 } ,
            { E_Buff.ThunderDown , 4 },
            { E_Buff.MagicDown , 4 }
        };

        //バフを付与
        yield return diffender.AppliyDeBuff( buffDic );
    }
}
