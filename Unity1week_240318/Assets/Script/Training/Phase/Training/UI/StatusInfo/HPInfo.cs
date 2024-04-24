using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class HPInfo : StatuInfoManager{
    

    protected override void UpdateText(S_SlimeTrainingData status){
        StatusNum.text = status.HP.ToString();
            LevelNum.text = status.HPLevel.ToString();
            if(status.HPLevel == 100){
                LevelNum.text = "MAX";
                isStatusMAX = true;
            }
    }
}
