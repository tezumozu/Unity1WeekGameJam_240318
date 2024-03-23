using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleUIManager : MonoBehaviour{
    private GameObject menuTextUI;
    private GameObject commandButtonUI;
    private GameObject skillListUI;
    private GameObject textBoxUI;


    Dictionary<E_BattleUIType,Action> UIList;
    GameObject cullentActiveUI;

    public void Start(){
        UIList = new Dictionary<E_BattleUIType,Action>();
        UIList[E_BattleUIType.Text] = ActiveText;
        UIList[E_BattleUIType.MeinMenu] = ActiveMeinMenu;
        UIList[E_BattleUIType.SkillList] = ActiveSkillList;

        //UI取得
        menuTextUI = gameObject.transform.Find("MenuText").gameObject;
        commandButtonUI = gameObject.transform.Find("CommandButton").gameObject;
        skillListUI = gameObject.transform.Find("SkillMenu").gameObject;
        textBoxUI = gameObject.transform.Find("TextBox").gameObject;

        //ボタンUIを監視
        var battleMenu = gameObject.GetComponent<BattleMenuManager>();
        var skillListMenu = gameObject.GetComponent<SkillListManager>();

        //魔法
        battleMenu.MagicButton.PushButtonAsync
        .Subscribe((type)=>{
            ChangeUI(type);
        })
        .AddTo(this);


        //戻る
        skillListMenu.BackButton.PushButtonAsync
        .Subscribe((type)=>{
            ChangeUI(type);
        })
        .AddTo(this);
        
        //UIの初期化
        UIList[E_BattleUIType.Text]();
    }

    public void ChangeUI(E_BattleUIType type){
        UIList[type]();
    }

    private void ActiveText(){
        menuTextUI.SetActive(false);
        commandButtonUI.SetActive(false);
        skillListUI.SetActive(false);
        textBoxUI.SetActive(true);
    }

    private void ActiveMeinMenu(){
        menuTextUI.SetActive(true);
        commandButtonUI.SetActive(true);
        skillListUI.SetActive(false);
        textBoxUI.SetActive(false);
    }

    private void ActiveSkillList(){
        menuTextUI.SetActive(false);
        commandButtonUI.SetActive(false);
        skillListUI.SetActive(true);
        textBoxUI.SetActive(false);
    }
}
