using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class DefenseInfo : StatuInfoManager{

    protected override void UpdateText(S_SlimeTrainingData status){
         StatusNum.text = status.Defense.ToString();
        LevelNum.text = status.DefenseLevel.ToString();
        if(status.DefenseLevel == 100){
            LevelNum.text = "MAX";
            isStatusMAX = true;
        }
    }
}
