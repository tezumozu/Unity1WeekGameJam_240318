using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCureEffect : AfterStatusEffect{

    int currentTrue;

    public AutoCureEffect() :base(E_AfterStatusEffect.Venom){
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        int cure = actor.GetMaxStatus.HP / 10;
        return actor.AppliyHeel(cure);
    }

    public override bool CheckContinueEffect(){
        currentTrue--;
        if(currentTrue <= 0){
            return false;
        }
        return true;
    }
}
