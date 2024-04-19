using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBuff_I_Action : BattleActorAction{

    public MagicBuff_I_Action():base(E_ActionType.MagicBuff_I){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.MagicUP , 3 );
    }
}
