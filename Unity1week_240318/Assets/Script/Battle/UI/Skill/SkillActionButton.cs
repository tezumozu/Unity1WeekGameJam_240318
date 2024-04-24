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
    ActionData actionData;
    ActionData currentActionData;
    bool isCanUse;
    bool isSilence;

    public override void OnClickButton(){
        PushButtonSubject.OnNext(MyType);

        skillInfoUIManager.SetActive(false);
    }


    public void InitSkillButton(E_ActionType type , SkillInfoUIManager infoUI ,  I_ActionCreatable actionFactory , PlayerUIManager statusManager , StatusEffectIconUI effectManager){
        skillInfoUIManager = infoUI;
        MyType = type;
        isCanUse = true;
        isSilence = false;
       
        actionData = actionFactory.CreateAction(type).ActionData;
        currentActionData = actionFactory.CreateAction(type).ActionData;

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
            isCanUse = false;
            button.interactable = false;
        }else{
            isCanUse = true;

            if(!isSilence){
                button.interactable = true;
            }
        }
    }

    //状態異常の更新時
    private void UpDateCost(E_BeforeStatusEffect effect){
        if(effect == E_BeforeStatusEffect.MPAccel){
            currentActionData.Cost = (int)( (float)actionData.Cost / 2 );
            skillCost.text = currentActionData.Cost.ToString();
            isSilence = false;

        }else if(effect == E_BeforeStatusEffect.Silence && actionData.AttackType == E_AttackType.Magic){
            button.interactable = false;
            isSilence = true;

        }else{
            currentActionData.Cost = actionData.Cost;
            skillCost.text = currentActionData.Cost.ToString();
            isSilence = false;

            if(isCanUse){
                button.interactable = true;
            }
        }
    }
}
