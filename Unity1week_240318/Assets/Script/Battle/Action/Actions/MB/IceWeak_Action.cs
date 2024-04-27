using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeak_Action : BattleActorAction{

    public IceWeak_Action():base(E_ActionType.IceWeak){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(diffender.GetCurrentStatus.Weakness == ActionData.Element){

            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.IceResistanceDown , 4},
                {E_Buff.DefenseDown , 4}
            };

            //バフを付与
            yield return diffender.AppliyDeBuff( buffList );
        }
    }
}
