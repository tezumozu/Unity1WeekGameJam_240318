using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilBuff_Action : BattleActorAction{

    public RecoilBuff_Action():base(E_ActionType.RecoilBuff){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return attacker.AppliyDamage( attacker.GetMaxStatus.HP * 3 /10 , E_Element.Constant );

        var buffList = new Dictionary<E_Buff,int>(){
            {E_Buff.AttackUP , 5},
            {E_Buff.NormalAttackUP , 5},
            {E_Buff.MagicUP , 5},
            {E_Buff.FlameUP , 5},
            {E_Buff.IceUP , 5},
            {E_Buff.ThunderUP , 5}
        };

        //バフを付与
        yield return attacker.AppliyBuff( buffList );
    }
}
