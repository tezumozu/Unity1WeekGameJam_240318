using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class EvoPauseUIManager : MonoBehaviour{
    [Inject]
    EvoGameManager gameManager;

    private Subject<Unit> BackToTitleSubject = new Subject<Unit>();
    public IObservable<Unit> BackToTitleAsync => BackToTitleSubject;

    [SerializeField]
    GameObject PauseUI;

    [SerializeField]
    GameObject CheckDisitionUI;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    [SerializeField]
    AudioClip cancellSE;

    private void Start() {
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            SetActive(flag);
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
