using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHIAttack_Action : BattleActorAction{

    public StatusEffectHIAttack_Action():base(E_ActionType.StatusEffectHIAttack){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        var damage = base.UseAction(effectedStatus,attacker,diffender);
        yield return damage;

        yield return attacker.AppliyMPHeel((int)damage.Current * 2 / 10);
    }

    public override bool checkSuccess(BattleActor Player,BattleActor Enemy){
        if(ActionData.SuccessRate < Random.Range(0.0f,1.0f)){
            return false;
        }

        if(Enemy.GetCurrentBeforeStatusEffect != E_BeforeStatusEffect.Non ){
            return true;
        }

        if(Enemy.GetCurrentAftoreStatusEffect != E_AfterStatusEffect.Non ){
            return true;
        }

        return false;  
    }
}
