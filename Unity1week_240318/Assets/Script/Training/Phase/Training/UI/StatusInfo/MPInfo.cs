using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class MPInfo : StatuInfoManager{

    protected override void UpdateText(S_SlimeTrainingData status){
        StatusNum.text = status.MP.ToString();
        LevelNum.text = status.MPLevel.ToString();
        if(status.MPLevel == 100){
            LevelNum.text = "MAX";
            isStatusMAX = true;
        }
    }
}
