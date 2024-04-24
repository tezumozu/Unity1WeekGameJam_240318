using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChance_Action : BattleActorAction{

    public GuardChance_Action():base(E_ActionType.GuardChance){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.Defense , 1 );

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Paralysis){

            //バフを付与
            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.FlameResistanceUP , 5},
                {E_Buff.IceResistanceUP , 5},
                {E_Buff.ThunderResistanceUP , 5}
            };

            //バフを付与
            yield return attacker.AppliyBuff( buffList );
        }
    }
}
