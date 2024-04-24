using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class SpeedInfo : StatuInfoManager{

    protected override void UpdateText(S_SlimeTrainingData status){
        StatusNum.text = status.Speed.ToString();
        LevelNum.text = status.SpeedLevel.ToString();
        if(status.SpeedLevel == 100){
            LevelNum.text = "MAX";
            isStatusMAX = true;
        }
    }

}
