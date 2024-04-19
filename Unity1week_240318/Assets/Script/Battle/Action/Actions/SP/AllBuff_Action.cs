using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBuff_Action : BattleActorAction{

    public AllBuff_Action():base(E_ActionType.AllBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        //全てのバフを付与
        Array array = Enum.GetValues(typeof(E_Buff));
        var buffFactory = new BuffFactory();
        var buffList = new Dictionary<E_Buff,int>();

        //無駄多い
        foreach (var type in array){
            var buff = buffFactory.CreateBuff((E_Buff)type,3);
            if(buff.BuffData.Type == E_BuffType.Buff){
                buffList[(E_Buff)type] = 3;
            }
        }

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
