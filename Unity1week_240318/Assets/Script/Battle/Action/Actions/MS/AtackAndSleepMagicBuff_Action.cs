using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAndSleepMagicBuff_Action : BattleActorAction{

    public AtackAndSleepMagicBuff_Action():base(E_ActionType.AtackAndSleepMagicBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Sleep){

            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.MagicUP , 5},
                {E_Buff.FlameUP , 5},
                {E_Buff.IceUP , 5},
                {E_Buff.ThunderUP , 5}
            };

            //バフを付与
            yield return attacker.AppliyBuff( buffList );
        }
    }
}
