using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceChance_Action : BattleActorAction{

    public IceChance_Action():base(E_ActionType.IceChance){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.IceUP , 5);

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            effectedStatus = attacker.GetCurrentEffectedStatus;
            yield return base.UseAction(effectedStatus,attacker,diffender);

        }
    }
}
