using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHi_II_Action : BattleActorAction{

    public PoisonHi_II_Action():base(E_ActionType.PoisonHi_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Poison || attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){
            //バフを付与
             var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.AttackUP , 5},
                {E_Buff.NormalAttackUP , 5}
            };

            //バフを付与
            yield return attacker.AppliyBuff( buffList );
        }
    }
}
