using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class SoundManager : MonoBehaviour{

    [SerializeField]
    Slider SoundSlider;

    [SerializeField]
    Slider SESlider;

    [SerializeField]
    Slider BGMSlider;

    private static S_SoundOptionData SoundOptionData = new S_SoundOptionData(0.5f , 0.5f , 0.5f);

    public static S_SoundOptionData GetSoundOptionData{
        get{return SoundOptionData;}
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);

        //現在の数値に直す
        SoundSlider.value = SoundOptionData.Sound;
        SESlider.value = SoundOptionData.SE;
        BGMSlider.value = SoundOptionData.BGM;
    }

    private Subject<S_SoundOptionData> UpdateOptionSubject = new Subject<S_SoundOptionData>();
    public IObservable<S_SoundOptionData> UpdateOptionAsync => UpdateOptionSubject;

    public void OnUpdateOption(){
        SoundOptionData = new S_SoundOptionData(SoundSlider.value , SESlider.value , BGMSlider.value);
        UpdateOptionSubject.OnNext(SoundOptionData);
    }
}
