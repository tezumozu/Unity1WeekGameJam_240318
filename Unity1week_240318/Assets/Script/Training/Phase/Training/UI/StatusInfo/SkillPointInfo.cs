using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using TMPro;
using Zenject;

public class SkillPointInfo : MonoBehaviour{
    [Inject]
    SlimeTrainingManager manager;

    [SerializeField]
    TextMeshProUGUI StatusNum;

    private void Start() {
        
        manager.UpdateTrainingStatusAsync
        .Subscribe((status) => {
            StatusNum.text = status.SkillPoint.ToString();
        })
        .AddTo(this);
    }
}
