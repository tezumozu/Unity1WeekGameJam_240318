using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiThunder_Action : BattleActorAction{

    public AntiThunder_Action():base(E_ActionType.AntiThunder){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //バフを付与
        yield return attacker.AppliyBuff( E_Buff.ThunderResistanceUP , 3 );

        //バフを付与
        yield return diffender.AppliyDeBuff( E_Buff.ThunderDown , 3 );
    }
}
