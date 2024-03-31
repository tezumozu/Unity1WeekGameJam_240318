using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class PlayerUIManager : ActorUIManager{

    Slider MPSlider;
    Text MPSliderNum;

    private Subject<S_BattleActorStatus> UpdateStatusSubject;
    public IObservable<S_BattleActorStatus> UpdateStatusAsync => UpdateStatusSubject;

    void Start(){
        //HPbarを取得
        HPSlider = StatusBer.transform.Find("HPBer/Slider").gameObject.GetComponent<Slider>();
        HPSliderNum = StatusBer.transform.Find("HPBer/Num").gameObject.GetComponent<Text>();
        //MPbarを取得
        MPSlider = StatusBer.transform.Find("MPBer/Slider").gameObject.GetComponent<Slider>();
        MPSliderNum = StatusBer.transform.Find("MPBer/Num").gameObject.GetComponent<Text>();
        
        UpdateStatusSubject = new Subject<S_BattleActorStatus>();
    }

    public override void SetStatus(S_BattleActorStatus currentStatus,S_BattleActorStatus maxStatus){
        HPSlider.value = (float)currentStatus.HP / (float)maxStatus.HP;
        HPSliderNum.text = currentStatus.HP.ToString();

        MPSlider.value = (float)currentStatus.MP / (float)maxStatus.MP;
        MPSliderNum.text = currentStatus.MP.ToString();

        UpdateStatusSubject.OnNext(currentStatus);
    }

    public override void SetBuffList(IEnumerable<BattleBuff> buffList){
        buffListUIManager.SetList(buffList,true);
    }
}
