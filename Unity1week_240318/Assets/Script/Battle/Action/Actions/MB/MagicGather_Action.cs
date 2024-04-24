using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGather_Action : BattleActorAction{

    public MagicGather_Action():base(E_ActionType.MagicGather){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.DefenseUP , 5},
            {E_Buff.FlameResistanceUP , 5},
            {E_Buff.IceResistanceUP , 5},
            {E_Buff.ThunderResistanceUP , 5},
            {E_Buff.MagicUP , 5},
            {E_Buff.FlameUP , 5},
            {E_Buff.IceUP , 5},
            {E_Buff.ThunderUP , 5}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
