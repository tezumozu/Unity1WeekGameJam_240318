using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class SkillActionButton : BattleActionButton{

    [SerializeField]
    Text skillName;

    [SerializeField]
    Text skillCost;

    [SerializeField]
    Button button;

    [SerializeField]
    Image buttonImage;


    SkillInfoUIManager skillInfoUIManager;
    E_ActionType skillType;
    ActionData actionData;
    ActionData currentActionData;

    public override void OnClickButton(){
        PushButtonSubject.OnNext(MyType);

        skillInfoUIManager.SetActive(false);
    }


    public void InitSkillButton(E_ActionType type , SkillInfoUIManager infoUI ,  I_ActionCreatable actionFactory , PlayerUIManager statusManager , StatusEffectIconUI effectManager){
        skillInfoUIManager = infoUI;
        skillType = type;
       
        actionData = actionFactory.CreateAction(type).ActionData;
        currentActionData = actionData;

        skillName.text = actionData.SkillName;
        skillCost.text = actionData.Cost.ToString();

        //ステータステーブルを取得
        //パスを生成
        var fileName = "BattleScene/UI/Image/SkillButton/" + ((int)actionData.Style).ToString();
        //読み込む
        var ButtonImage =  Resources.Load<Sprite>(fileName);

        if(ButtonImage is null){
            Debug.Log("Load error! : SkillAction");
        }

        buttonImage.sprite = ButtonImage;

        statusManager.UpdateStatusAsync
        .Subscribe((status) => {
            UpDateStatus(status.MP);
        })
        .AddTo(this);

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

        //状態異常の更新を監視
        effectManager.BeforeEffectUpdateAsync
        .Subscribe((type)=>{
            UpDateCost(type);
        }).AddTo(this);
    }

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    // this method called by mouse-pointer enter the object.
    public void OnPointerEnter( ){
        skillInfoUIManager.SetInfo(currentActionData);
        skillInfoUIManager.SetActive(true);
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    // 
    public void OnPointerExit( ){
        skillInfoUIManager.SetActive(false);
    }

    //ステータス更新時の処理
    private void UpDateStatus(int MP){
        if(actionData.Cost > MP){
            button.interactable = false;
        }
    }

    //状態異常の更新時
    private void UpDateCost(E_BeforeStatusEffect effect){
        if(effect == E_BeforeStatusEffect.MPAccel){
            currentActionData.Cost = (int)( (float)currentActionData.Cost / 2 );
        }else{
            currentActionData.Cost = actionData.Cost;
        }
    }
}
