using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGuard_Action : BattleActorAction{

    public AllGuard_Action():base(E_ActionType.AllGuard){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        //バフを付与
        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.Defense,3},
            {E_Buff.DefenseUP,3}
        };

        yield return attacker.AppliyBuff( buffList );

        //状態異常ガード付与
        yield return attacker.AppliyEffect(E_AfterStatusEffect.EffectProtect);
        yield return attacker.AppliyEffect(E_BeforeStatusEffect.EffectProtect);
        
    }
}
