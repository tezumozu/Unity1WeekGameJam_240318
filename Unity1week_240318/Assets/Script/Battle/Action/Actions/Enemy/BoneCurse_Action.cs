using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCurse_Action : BattleActorAction{

    public BoneCurse_Action():base(E_ActionType.BoneCurse){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.FlameUP , 5 );
        yield return diffender.AppliyDeBuff( E_Buff.FlameResistanceUP , 5 );
    }
}
