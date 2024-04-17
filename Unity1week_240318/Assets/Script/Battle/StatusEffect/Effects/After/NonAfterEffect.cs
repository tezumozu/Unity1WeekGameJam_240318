using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonAfterEffect : AfterStatusEffect{

    public NonAfterEffect():base(E_AfterStatusEffect.Non){
    }

    public override IEnumerator AppliyEffect(BattleActor actor){
        yield return null;
    }

    public override bool CheckContinueEffect(){
        return true;
    }
}
