using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderWeak_Action : BattleActorAction{

    public ThunderWeak_Action():base(E_ActionType.ThunderWeak){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(diffender.GetCurrentStatus.Weakness == ActionData.Element){

            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.ThunderResistanceDown , 4},
                {E_Buff.DefenseDown , 4}
            };

            //バフを付与
            yield return diffender.AppliyDeBuff( buffList );
        }
    }
}
