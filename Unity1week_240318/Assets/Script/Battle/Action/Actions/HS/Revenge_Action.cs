using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revenge_Action : BattleActorAction{

    public Revenge_Action():base(E_ActionType.Revenge){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        //バフを付与
        yield return attacker.AppliyHeel( (int)((float)attacker.GetMaxStatus.HP * 0.5) );
        yield return attacker.AppliyBuff( E_Buff.AttackUP , 3 );
    }

    public override bool checkSuccess(BattleActor Player,BattleActor Enemy){
        if(ActionData.SuccessRate < Random.Range(0.0f,1.0f)){
            return false;
        }

        if(Player.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Poison || Player.GetCurrentAftoreStatusEffect == E_AfterStatusEffect.Venom){
            return true;
        }
        
        return false;
    }
}
