using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class BlackOutManager : MonoBehaviour{

    [SerializeField]
    private Animator BlackOutAnimator;


    private Subject<Unit> FinishAnimSubject = new Subject<Unit>();
    public IObservable<Unit> FinishAnimAsync => FinishAnimSubject;

    public void StartBlackOutAnim(){
        gameObject.SetActive(true);
        BlackOutAnimator.SetTrigger("OutAnimTrigger");
    }

    public void StartBlackInAnim(){
        gameObject.SetActive(true);
        BlackOutAnimator.SetTrigger("InAnimTrigger");
    }

    public void FinishAnim(){
        FinishAnimSubject.OnNext(Unit.Default);
        gameObject.SetActive(false);
    }
}
