using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWeak_Action : BattleActorAction{

    public FlameWeak_Action():base(E_ActionType.FlameWeak){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        if(diffender.GetCurrentStatus.Weakness == ActionData.Element){

            var buffList = new Dictionary<E_Buff,int>(){
                {E_Buff.FlameResistanceDown , 2},
                {E_Buff.DefenseDown , 2}
            };

            //バフを付与
            yield return diffender.AppliyDeBuff( buffList );
        }
        
    }
}
