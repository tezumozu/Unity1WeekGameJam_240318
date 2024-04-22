using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TitleInputManager : InGameInputManager{

    private Subject<Unit> OptionButtonSubject = new Subject<Unit>();
    public IObservable<Unit> OptionButtonAsync => OptionButtonSubject;

    private Subject<Unit> HowToPlaySubject = new Subject<Unit>();
    public IObservable<Unit> HowToPlayAsync => HowToPlaySubject;

    private Subject<Unit> StartGameSubject = new Subject<Unit>();
    public IObservable<Unit> StartGameAsync => StartGameSubject;

    [SerializeField]
    TitleOptionManager optionManager;

    [SerializeField]
    HowToPlayManager HowToPlayManager;

    void Start(){
        optionManager.BackToTitleAsync
        .Subscribe((_)=>{
            gameObject.SetActive(true);
        })
        .AddTo(this);

        HowToPlayManager.BackToTitleAsync
        .Subscribe((_)=>{
            gameObject.SetActive(true);
        })
        .AddTo(this);
    }
    
    public void StartGame(){
        StartGameSubject.OnNext(Unit.Default);
    }

    public void ActiveOption(){
        OptionButtonSubject.OnNext(Unit.Default);
        gameObject.SetActive(false);
    }

    public void ActiveHowToPlay(){
        HowToPlaySubject.OnNext(Unit.Default);
        gameObject.SetActive(false);
    }
}
