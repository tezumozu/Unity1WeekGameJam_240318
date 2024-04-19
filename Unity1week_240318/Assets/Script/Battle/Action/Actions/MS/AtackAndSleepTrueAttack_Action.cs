using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAndSleepTrueAttack_Action : BattleActorAction{

    public AtackAndSleepTrueAttack_Action():base(E_ActionType.AtackAndSleepTrueAttack){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        if(diffender.GetCurrentBeforeStatusEffect == E_BeforeStatusEffect.Sleep){

            //攻撃側の攻撃力を計算
            int attackPoint = (int)((float)CalculateAttackPoint(effectedStatus) * getDamageRamd());

            //クリティカル判定
            if(isCritical){
                attackPoint = (int)((float)attackPoint * 1.5f);
            }

            //ダメージ計算の終了待ちをする
            var damageCalculate = diffender.AppliyDamage(attackPoint,E_Element.TrueDamage);
            yield return damageCalculate;
            
            int result = (int)damageCalculate.Current;

            yield return result;

        }else{
            //通常攻撃
            yield return base.UseAction(effectedStatus,attacker,diffender);
        }
    }
}
