using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class PlayerBattleActor : BattleActor{


    public PlayerBattleActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory):base(actionFactory,buffFactory,statusEffectFactory){
        //マネージャの取得
        statusUIManager = GameObject.Find("Canvas/PlayerUI").GetComponent<ActorUIManager>();
        actorAnimManager = GameObject.Find("Canvas/PlayerUI").GetComponent<ActorAnimManager>();
        var skillListMenu = GameObject.Find("Canvas/BattleUI").GetComponent<SkillListManager>();
        
        //ステータスの生成
        //スキルリストを取得
        maxStatus = PlayerData.GetPlayerStatus;
        currentStatus = PlayerData.GetPlayerStatus;

        //UI初期化
        //スキルリストをセット
        skillListMenu.setSkillList(PlayerData.GetPlayerSkillList);
        //プレイヤーのステータスをセット
        statusUIManager.SetStatus(currentStatus,currentStatus);
        statusUIManager.SetSprite(currentStatus.Image);
        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);
        statusUIManager.SetBuffList(buffDic.Values);

        finishAnimDispose = actorAnimManager.FinishAnimAsync.Subscribe((type)=>{
            isFinishAnim = true;
        });
    }



    public override IEnumerator SetNextAction(){
        //UIを切り替える
        uiManager.ChangeUI(E_BattleUIType.MeinMenu);

        var coroutine = inputManager.WaitPushButton();
        CoroutineHander.OrderStartCoroutine(coroutine);

        //入力待ちをする
        yield return coroutine;

        currentAction = actionFactory.CreateAction((E_ActionType)coroutine.Current);

    }



    public void ResetState(){
        
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //バフをリセット
        buffDic.Clear();

        //状態異常をリセット
        currentBeforeStatusEffect = statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
        currentAfterStatusEffect = statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);

        //アクションリセット
        currentAction = actionFactory.CreateAction(E_ActionType.Attack);

        //UI更新
        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);
        statusUIManager.SetBuffList(buffDic.Values);
    }

    public override void Dispose(){
        base.Dispose();
    }
}
