using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMagicBuff_Action : BattleActorAction{

    public AllMagicBuff_Action():base(E_ActionType.AllMagicBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.FlameUP,5},
            {E_Buff.IceUP,5},
            {E_Buff.ThunderUP,5},
            {E_Buff.MagicUP,5},
        };

        yield return attacker.AppliyBuff( buffList );
    }
}
