using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;


public class HowToPlayManager : MonoBehaviour{
    private Subject<Unit> BackToTitleSubject = new Subject<Unit>();
    public IObservable<Unit> BackToTitleAsync => BackToTitleSubject;

    [SerializeField]
    TitleInputManager TitleInputManager;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    [SerializeField]
    AudioClip cancellSE;

    [SerializeField]
    AudioClip clickSE;

    [SerializeField]
    List<Sprite> pageList;

    [SerializeField]
    Image ImageUI;

    int pageCount = 0;

    private void Start() {
        TitleInputManager.HowToPlayAsync
        .Subscribe((_)=>{
            SetActive(true);
            soundPlayer.PlaySE(desitionSE);
        })
        .AddTo(this);

        SetActive(false);

        ImageUI.sprite = pageList[pageCount];
    }

    public void OnPushBackToTitleButton(){
        soundPlayer.PlaySE(cancellSE);
        BackToTitleSubject.OnNext(Unit.Default);
        SetActive(false);
    }

    private void SetActive(bool flag){
        pageCount = 0;
        ImageUI.sprite = pageList[pageCount];
        gameObject.SetActive(flag);
    }

    public void NextPage(){
        soundPlayer.PlaySE(clickSE);
        pageCount = (pageCount + 1) % pageList.Count;
        ImageUI.sprite = pageList[pageCount];
    }

    public void BackPage(){
        soundPlayer.PlaySE(clickSE);
        pageCount = (pageCount - 1);

        if(pageCount < 0){
            pageCount = pageList.Count-1;
        }

        ImageUI.sprite = pageList[pageCount];
    }
}
