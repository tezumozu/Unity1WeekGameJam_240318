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
    SoundManager soundManager;

    public void OnPushBackToTitleButton(){
        CheckDisitionUI.SetActive(true);
    }

    public void CanselBackToTitle(){
        CheckDisitionUI.SetActive(false);
    }

    public void DisitionBackToTitle(){
        BackToTitleSubject.OnNext(Unit.Default);
    }

    public void SetActive(bool flag){
        if(!flag) CheckDisitionUI.SetActive(false);
        gameObject.SetActive(flag);
        soundManager.SetActive(flag);
    }
}
