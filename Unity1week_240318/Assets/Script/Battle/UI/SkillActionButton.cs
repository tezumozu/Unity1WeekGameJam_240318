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


    SkillInfoUIManager skillInfoUIManager;
    E_ActionType skillType;
    ActionData actionData;

    public override void OnClickButton(){
        PushButtonSubject.OnNext(MyType);

        skillInfoUIManager.SetActive(false);
    }


    public void InitSkillButton(E_ActionType type , SkillInfoUIManager infoUI ,  I_ActionCreatable actionFactory){
        skillInfoUIManager = infoUI;
        skillType = type;
       
        actionData = actionFactory.CreateAction(type).ActionData;

        skillName.text = actionData.SkillName;
        skillCost.text = actionData.Cost.ToString();
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
}
