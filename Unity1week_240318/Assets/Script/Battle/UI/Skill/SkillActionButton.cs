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

    [SerializeField]
    Sprite NotActiveButtonImage;


    SkillInfoUIManager skillInfoUIManager;
    E_ActionType skillType;
    ActionData actionData;

    public override void OnClickButton(){
        PushButtonSubject.OnNext(MyType);

        skillInfoUIManager.SetActive(false);
    }


    public void InitSkillButton(E_ActionType type , SkillInfoUIManager infoUI ,  I_ActionCreatable actionFactory , PlayerUIManager statusManager){
        skillInfoUIManager = infoUI;
        skillType = type;
       
        actionData = actionFactory.CreateAction(type).ActionData;

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
    }

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    // this method called by mouse-pointer enter the object.
    public void OnPointerEnter( ){
        skillInfoUIManager.SetInfo(actionData);
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
            buttonImage.sprite = NotActiveButtonImage;
        }
    }
}
