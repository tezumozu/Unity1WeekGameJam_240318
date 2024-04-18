using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowUP_Action : BattleActorAction{

    public GrowUP_Action():base(E_ActionType.GrowUP){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){
        
        //バフを付与
        var buffList = new Dictionary<E_Buff,int>(){
            { E_Buff.AttackUP , 5 } , 
            { E_Buff.NormalAttackUP , 5 }
        };

        yield return attacker.AppliyBuff( buffList );
    }
}
