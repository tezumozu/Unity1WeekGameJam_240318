using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleActor : BattleActor{

    public PlayerBattleActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        //ステータスの生成
        //スキルリストを取得
        maxStatus = PlayerData.GetPlayerStatus;
        currentStatus = PlayerData.GetPlayerStatus;
        skillList = PlayerData.GetPlayerSkillList;

        //初期化
        isStan = false;
    }


    public override List<string> CheckBeforeStatusEffect(){
        //前分を表示
        var resultTextList = new List<string>();
        if(currentBeforeStatusEffect.Type != E_BeforeStatusEffect.Non){
            resultTextList.Add(currentStatus.Name + " " + currentBeforeStatusEffect.EffectText);
        }

        return resultTextList;
    }


    public override List<string> ActionBattleActor(E_ActionType type,I_DamageApplicable enemy){

        var resultTextList = new List<string>();

        //該当のアクションを生成
        CurrentAction = actionFactotry.CreateAction(type);

        //もしこのターン状態異常の影響を受けたなら
        if(currentBeforeStatusEffect.AppliyEffect(this)){
            CurrentAction = currentBeforeStatusEffect.EffectAction;
        };

        //ステータスをバフごとに補正
        S_BattleActorStatus effectedStatus = currentStatus;

        foreach (var item in buffDic){
           effectedStatus = item.Value.EffectedBuff(effectedStatus,CurrentAction);
        }

        //アクションを使用する
        var actionResult = CurrentAction.UseAction(this,enemy);
        //テキストを追加
        resultTextList.AddRange(actionResult.ResultTextList);


        //アクションのコスト分、ＭＰを消費する
        currentStatus.MP = currentStatus.MP - CurrentAction.ActionData.Cost;

        return resultTextList;
    }


    public override List<string> CheckAfterStatusEffect(){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> RefreshBattleActor(){
        var resultTextList = new List<string>();
        //バフの処理
        //状態異常A
        if(currentBeforeStatusEffect.Type != E_BeforeStatusEffect.Non){
            if(!currentBeforeStatusEffect.CheckContinueEffect()){
                resultTextList.Add(currentStatus.Name + " " + currentBeforeStatusEffect.RecoveryText);
                currentBeforeStatusEffect = statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
            }
        }
        //状態異常B

        return resultTextList;
    }

    //ランダムで行動が必要な時用(混乱時など)
    protected List<string> ActionBattleActor(I_DamageApplicable enemy){
        var resultTextList = new List<string>();

        return resultTextList;
    }

    public void ResetState(){
        //バフをリセット
        buffDic.Clear();

        //状態異常をリセット
        currentBeforeStatusEffect = statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
        currentAfterStatusEffect = statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);
    }
}
