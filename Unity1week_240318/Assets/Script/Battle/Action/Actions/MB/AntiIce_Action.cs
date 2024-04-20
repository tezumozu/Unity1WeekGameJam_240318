using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiIce_Action : BattleActorAction{

    public AntiIce_Action():base(E_ActionType.AntiIce){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.IceResistanceUP , 3 );

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.IceDown , 2 );
    }
}
