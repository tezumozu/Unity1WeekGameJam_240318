using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class AttackInfo : StatuInfoManager{

    protected override void UpdateText(S_SlimeTrainingData status){
        LevelNum.text = status.AttackLevel.ToString();
        StatusNum.text = status.Attack.ToString();
        if(status.AttackLevel == 100){
            LevelNum.text = "MAX";
            isStatusMAX = true;
        }
    }
}
