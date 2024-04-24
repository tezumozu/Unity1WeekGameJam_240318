using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDefense_Action : BattleActorAction{

    public PowerDefense_Action():base(E_ActionType.PowerDefense){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.Defense ,5 );
    }
}
