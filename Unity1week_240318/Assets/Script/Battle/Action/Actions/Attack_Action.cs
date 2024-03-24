using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Action : BattleActorAction{

    public Attack_Action():base(E_ActionType.Attack){

    }

    public override ActionResult UseAction(BattleActor attacker , I_DamageApplicable diffender){

        var resultTextList = new List<string>();
        //テキストを追加
        resultTextList.Add(attacker.GetCurrentStatus.Name + "の攻撃！");

        //攻撃側の攻撃力を計算
        int attackPoint = attacker.GetCurrentStatus.Attack * (ActionData.Power / 100) + 1;

            //クリティカル判定
        if(attacker.GetCurrentStatus.CriticalCorrection * ActionData.CriticalRate > Random.Range( 0.0f , 1.0f )){
            attackPoint = (int)(attackPoint * 1.5f);
        }

            //ダメージ乱数
        attackPoint = (int)(attackPoint * Random.Range( 0.9f , 1.1f ));

        int damage = diffender.DamageAppliy(attackPoint,ActionData.Element);

        return new ActionResult(damage,resultTextList);
    }
}
