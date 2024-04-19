using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ironclad_Action : BattleActorAction{

    public Ironclad_Action():base(E_ActionType.Ironclad){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense , 5},
            {E_Buff.FlameResistanceUP , 5},
            {E_Buff.IceResistanceUP , 5},
            {E_Buff.ThunderResistanceUP , 5}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );

        yield return attacker.AppliyEffect( E_BeforeStatusEffect.EffectProtect );
        yield return attacker.AppliyEffect( E_AfterStatusEffect.EffectProtect );
    }
}
