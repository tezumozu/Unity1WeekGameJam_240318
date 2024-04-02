using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class TitleOptionManager : MonoBehaviour{
    private Subject<Unit> BackToTitleSubject = new Subject<Unit>();
    public IObservable<Unit> BackToTitleAsync => BackToTitleSubject;

    [SerializeField]
    SoundManager SoundManager;

    [SerializeField]
    TitleInputManager TitleInputManager;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    [SerializeField]
    AudioClip cancellSE;

    private void Start() {
        TitleInputManager.OptionButtonAsync
        .Subscribe((_)=>{
            SetActive(true);
            soundPlayer.PlaySE(desitionSE);
        })
        .AddTo(this);
        SetActive(false);
    }

    public void OnPushBackToTitleButton(){
        soundPlayer.PlaySE(cancellSE);
        BackToTitleSubject.OnNext(Unit.Default);
        SetActive(false);
    }

    private void SetActive(bool flag){
        SoundManager.SetActive(flag);
        gameObject.SetActive(flag);
    }
}
