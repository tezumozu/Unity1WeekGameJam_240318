using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class PauseUIManager : MonoBehaviour{
    private Subject<Unit> BackToTitleSubject = new Subject<Unit>();
    public IObservable<Unit> BackToTitleAsync => BackToTitleSubject;

    [SerializeField]
    GameObject PauseUI;

    [SerializeField]
    GameObject CheckDisitionUI;

    [SerializeField]
    BattleInputManager battleInputManager;

    [SerializeField]
    PauseInputManager pauseInputManager;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    [SerializeField]
    AudioClip cancellSE;

    private void Start() {
        battleInputManager.escAsync
        .Subscribe((_)=>{
            soundPlayer.PlaySE(desitionSE);
            SetActive(true);
        })
        .AddTo(this);

        pauseInputManager.escAsync
        .Subscribe((_)=>{
            soundPlayer.PlaySE(cancellSE);
            SetActive(false);
        })
        .AddTo(this);

        SetActive(false);
    }

    public void OnPushBackToTitleButton(){
        soundPlayer.PlaySE(desitionSE);
        CheckDisitionUI.SetActive(true);
    }

    public void CanselBackToTitle(){
        soundPlayer.PlaySE(cancellSE);
        CheckDisitionUI.SetActive(false);
    }

    public void DisitionBackToTitle(){
        soundPlayer.PlaySE(desitionSE);
        BackToTitleSubject.OnNext(Unit.Default);
    }

    private void SetActive(bool flag){
        if(!flag) CheckDisitionUI.SetActive(false);
        gameObject.SetActive(flag);
    }
}
