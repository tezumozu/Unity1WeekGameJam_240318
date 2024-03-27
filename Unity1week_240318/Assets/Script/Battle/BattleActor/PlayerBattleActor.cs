using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class PlayerBattleActor : BattleActor{
    IDisposable actionInputedDisposable;
    bool isActinInputed;


    public PlayerBattleActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        //マネージャの取得
        statusUIManager = GameObject.Find("Canvas/PlayerUI").GetComponent<ActorUIManager>();
        var skillListMenu = GameObject.Find("Canvas/BattleUI").GetComponent<SkillListManager>();
        
        //ステータスの生成
        //スキルリストを取得
        maxStatus = PlayerData.GetPlayerStatus;
        currentStatus = PlayerData.GetPlayerStatus;
        skillList = PlayerData.GetPlayerSkillList;

        //購読
        isActinInputed = false;

        actionInputedDisposable = inputManager.ActionUIAsync.Subscribe((type)=>{
            currentActionType = type;
            isActinInputed = true;
        });

        //UI初期化
        //スキルリストをセット
        skillListMenu.setSkillList(skillList);
        //プレイヤーのステータスをセット
        statusUIManager.SetStatus(currentStatus,currentStatus);
        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);
        statusUIManager.SetBuffList(buffDic.Values);
    }



    public override IEnumerator SetNextAction(){
        //UIを切り替える
        uiManager.ChangeUI(E_BattleUIType.MeinMenu);

        //入力待ちをする
        isActinInputed = false;
        while (!isActinInputed){
            yield return null;
        }
    }



    public void ResetState(){
        Debug.Log(currentActionType);
        
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //バフをリセット
        buffDic.Clear();

        //状態異常をリセット
        currentBeforeStatusEffect = statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
        currentAfterStatusEffect = statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);

        //UI更新
        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);
        statusUIManager.SetBuffList(buffDic.Values);
    }

    public override void Dispose(){
        base.Dispose();
        actionInputedDisposable.Dispose();
    }
}
