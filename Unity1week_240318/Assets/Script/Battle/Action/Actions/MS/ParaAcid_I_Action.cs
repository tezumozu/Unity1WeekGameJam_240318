using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaAcid_I_Action : BattleActorAction{

    public ParaAcid_I_Action():base(E_ActionType.ParaAcid_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return diffender.AppliyEffect( E_BeforeStatusEffect.Paralysis );

        //バフを付与
        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.FlameResistanceDown , 5},
            {E_Buff.IceResistanceDown , 5},
            {E_Buff.ThunderResistanceDown , 5}
        };

        //バフを付与
        yield return diffender.AppliyDeBuff( buffList );
    }
}
