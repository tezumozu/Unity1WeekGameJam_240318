using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomMedicine_Action : BattleActorAction{

    public VenomMedicine_Action():base(E_ActionType.VenomMedicine){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(attacker.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){

            //バフを付与
            yield return attacker.AppliyHeel( attacker.GetMaxStatus.HP * 75 / 100 );

            yield return attacker.ClearBuff( E_BuffType.Debuff );

            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.DefenseUP , 5},
                {E_Buff.FlameResistanceUP , 5},
                {E_Buff.IceResistanceUP , 5},
                {E_Buff.ThunderResistanceUP , 5},
            };

            //バフを付与
            yield return attacker.AppliyBuff( buffList );

        }else{
            yield return attacker.AppliyEffect( E_AfterStatusEffect.Venom );
        }
    }
}
