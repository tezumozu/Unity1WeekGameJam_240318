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

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    private Subject<S_SoundOptionData> UpdateOptionSubject = new Subject<S_SoundOptionData>();
    public IObservable<S_SoundOptionData> UpdateOptionAsync => UpdateOptionSubject;

    private static S_SoundOptionData SoundOptionData = new S_SoundOptionData(0.5f , 0.5f , 0.5f);

    public static S_SoundOptionData GetSoundOptionData{
        get{return SoundOptionData;}
    }

    private void Start() {
        //現在の数値に直す
        SoundSlider.value = SoundOptionData.Sound;
        SESlider.value = SoundOptionData.SE;
        BGMSlider.value = SoundOptionData.BGM;
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);

        //現在の数値に直す
        SoundSlider.value = SoundOptionData.Sound;
        SESlider.value = SoundOptionData.SE;
        BGMSlider.value = SoundOptionData.BGM;
    }

    public void OnUpdateOption(){
        SoundOptionData = new S_SoundOptionData(SoundSlider.value , SESlider.value , BGMSlider.value);
        UpdateOptionSubject.OnNext(SoundOptionData);
        soundPlayer.PlaySE(desitionSE);
    }
}
