using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Action : BattleActorAction{

    public Attack_Action():base(E_ActionType.Attack){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus, I_DamageApplicable attacker , I_DamageApplicable diffender){

        //攻撃側の攻撃力を計算
        int attackPoint = (int)((float)effectedStatus.Attack * (float)ActionData.Power);

            //クリティカル判定
        if(isCritical){
            attackPoint = (int)((float)attackPoint * 1.5f);
        }

        //ダメージ計算の終了待ちをする
        yield return diffender.AppliyDamage(attackPoint,ActionData.Element);
    }
}
