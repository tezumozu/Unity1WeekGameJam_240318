using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;


public class SkillListManager : MonoBehaviour{

    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private GameObject ButtonPrefb;

    [SerializeField]
    private PlayerUIManager statusManager;

    [SerializeField]
    private StatusEffectIconUI effectManager;

    [SerializeField]
    private GameObject infoUI;
    private SkillInfoUIManager infoUIManager;


    private Subject<List<BattleActionButton>> UpdateUISubject = new Subject<List<BattleActionButton>>();
    public IObservable<List<BattleActionButton>> UpdateUIAsync => UpdateUISubject;

    public BattleUIControlButton BackButton {get; private set;}

    void Start(){
        BackButton = gameObject.transform.Find("SkillMenu/BackButton").gameObject.GetComponent<BattleUIControlButton>();
        infoUIManager = infoUI.GetComponent<SkillInfoUIManager>();
    }

    public void setSkillList(List<E_ActionType> skillList){
        var buttonList = new List<BattleActionButton>();

        float isSclorl = 0.0f;

        float ButtonHight = 50;
        float ButtonWidth = 200;

        //リストのサイズからContensのHightを変更
        float ContentHight = Mathf.Ceil(((float)skillList.Count)/3) * ButtonHight + 25 * (Mathf.Ceil(((float)skillList.Count)/3)-1) + 50;

        if(ContentHight < 175.0f){
            ContentHight = 175.0f;
            isSclorl = -1.0f;
        }

        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,ContentHight);

        //現在のContent内のオブジェクトを削除
        var transform = content.transform;
        foreach(Transform Button in transform){
            Destroy(Button.gameObject);
        }

        int count = 0;
        int columnCount = 0;

        foreach (var skill in skillList){

            //座標計算
            float x = (count - 1) * ButtonWidth + (count - 1) * 25 - 10 * isSclorl;
            float y = ContentHight/2 - columnCount * (ButtonHight + 25) - ButtonHight / 2 - 25;

            var pos = new Vector2(x,y);

            //インスタンス化
            var buttonObject = Instantiate(ButtonPrefb);

            // プレハブを指定位置に設置
            var rect_transform = buttonObject.GetComponent<RectTransform>();
            rect_transform.position = pos;

            //buttonを初期化
            var button = buttonObject.GetComponent<SkillActionButton>();
            button.InitSkillButton(skill,infoUIManager,new ActionFactory(),statusManager,effectManager);

            //Contensへ格納
            buttonObject.transform.SetParent(content,false);

            //ボタンリストに追加
            buttonList.Add(button);   

            count++;
            count = count % 3;
            if(count == 0){
                columnCount++;
            }
        }

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

        UpdateUISubject.OnNext(buttonList);
    }
}
