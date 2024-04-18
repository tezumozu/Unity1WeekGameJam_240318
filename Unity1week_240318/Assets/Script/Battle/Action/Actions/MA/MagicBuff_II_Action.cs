using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBuff_II_Action : BattleActorAction{

    public MagicBuff_II_Action():base(E_ActionType.MagicBuff_II){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyBuff( E_Buff.MagicUP , 5 );
    }
}
