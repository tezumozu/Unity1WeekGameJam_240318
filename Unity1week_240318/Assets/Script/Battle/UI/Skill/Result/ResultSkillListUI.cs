using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;


public class ResultSkillListManager : MonoBehaviour{

    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private GameObject ButtonPrefb;

    [SerializeField]
    private ResultSkillInfoUI infoUIManager;

    public void SetSkillList(List<E_ActionType> skillList){

        float ButtonHight = 30.0f;
        float ButtonWidth = 160.0f;

        //リストのサイズからContensのHightを変更
        float ContentHight = 12.5f + (ButtonHight + 12.5f) * skillList.Count;

        if(ContentHight < 280.0f){
            ContentHight = 280.0f;
        }

        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,ContentHight);

        //現在のContent内のオブジェクトを削除
        var transform = content.transform;
        foreach(Transform Button in transform){
            Destroy(Button.gameObject);
        }

        int count = 0;

        foreach (var skill in skillList){
            //座標計算
            float y = ContentHight/2 - (float)count * (ButtonHight + 12.5f) - ButtonHight / 2 - 12.5f;
            var pos = new Vector2( 8.5f , y );

            //インスタンス化
            var buttonObject = Instantiate(ButtonPrefb);

            // プレハブを指定位置に設置
            var rect_transform = buttonObject.GetComponent<RectTransform>();
            rect_transform.position = pos;

            //buttonを初期化
            var button = buttonObject.GetComponent<ResultSkillButton>();
            var action = new ActionFactory().CreateAction(skill);
            button.InitSkillButton(action.ActionData,infoUIManager);

            //Contensへ格納
            buttonObject.transform.SetParent(content,false); 

            count++;
        }
    }
}
