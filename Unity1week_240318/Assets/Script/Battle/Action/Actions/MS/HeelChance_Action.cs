using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelChance_Action : BattleActorAction{

    public HeelChance_Action():base(E_ActionType.HeelChance){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyHeel( attacker.GetMaxStatus.HP * 3 / 4 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            //バフを付与
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
