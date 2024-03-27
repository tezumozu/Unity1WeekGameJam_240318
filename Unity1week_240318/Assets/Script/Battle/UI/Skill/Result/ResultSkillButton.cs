using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultSkillButton : MonoBehaviour{

    [SerializeField]
    TextMeshProUGUI skillName;

    ResultSkillInfoUI skillInfoUIManager;
    ActionData actionData;

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    public void OnPointerEnter( ){
        skillInfoUIManager.SetInfo(actionData);
        skillInfoUIManager.SetActive(true);
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    public void OnPointerExit( ){
        skillInfoUIManager.SetActive(false);
    }

    public void InitSkillButton(ActionData data , ResultSkillInfoUI infoUIManager){
        skillInfoUIManager = infoUIManager;
       
        actionData = data;
        skillName.text = actionData.SkillName;
    }

}
