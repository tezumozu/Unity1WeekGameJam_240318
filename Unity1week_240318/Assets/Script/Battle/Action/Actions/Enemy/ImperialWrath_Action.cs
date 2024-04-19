using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImperialWrath_Action : BattleActorAction{

    public ImperialWrath_Action():base(E_ActionType.ImperialWrath){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.AttackUP , 5},
            {E_Buff.MagicUP , 5},
            {E_Buff.FlameUP , 5},
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );

        yield return attacker.AppliyEffect( E_BeforeStatusEffect.EffectProtect );
        yield return attacker.AppliyEffect( E_AfterStatusEffect.EffectProtect );
    }
}
