using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ResultSkillButton : MonoBehaviour{

    [SerializeField]
    TextMeshProUGUI skillName;

    [SerializeField]
    Image buttonImage;

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

        //ステータステーブルを取得
        //パスを生成
        var fileName = "BattleScene/UI/Image/SkillButton/" + ((int)actionData.Style).ToString();
        //読み込む
        var ButtonImage =  Resources.Load<Sprite>(fileName);

        if(ButtonImage is null){
            Debug.Log("Load error! : SkillAction");
        }

        buttonImage.sprite = ButtonImage;

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();
    }

}
