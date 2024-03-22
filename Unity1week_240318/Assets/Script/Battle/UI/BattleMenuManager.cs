using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleMenuManager : MonoBehaviour{
    public BattleActionButton AttackButton {get; private set;}
    public BattleActionButton DefenseButton {get; private set;}
    public BattleUIControlButton MagicButton {get; private set;}

    void Start(){
        AttackButton = gameObject.transform.Find("CommandButton/AttackButton").gameObject.GetComponent<BattleActionButton>();
        DefenseButton = gameObject.transform.Find("CommandButton/DefenseButton").gameObject.GetComponent<BattleActionButton>();
        MagicButton = gameObject.transform.Find("CommandButton/MagicButton").gameObject.GetComponent<BattleUIControlButton>();
    }

    public void SetText(string text){

    }
}
