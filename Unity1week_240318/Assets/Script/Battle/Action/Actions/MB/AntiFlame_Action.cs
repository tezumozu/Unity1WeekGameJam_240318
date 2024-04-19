using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiFlame_Action : BattleActorAction{

    public AntiFlame_Action():base(E_ActionType.AntiFlame){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.FlameResistanceUP , 3 );

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.FlameDown , 3 );
    }
}
