using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomDrug_Action : BattleActorAction{

    public VenomDrug_Action():base(E_ActionType.VenomDrug){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyEffect( E_AfterStatusEffect.Venom );

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.AttackUP , 5},
            {E_Buff.NormalAttackUP , 5}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );

        yield return attacker.AppliyEffect( E_BeforeStatusEffect.MPAccel );
    }
}
