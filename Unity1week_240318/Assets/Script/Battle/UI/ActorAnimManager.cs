using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class ActorAnimManager : MonoBehaviour{

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    Animator actorAnimator;

    private Subject<Unit> finishAnimSubject = new Subject<Unit>();
    public IObservable<Unit> FinishAnimAsync => finishAnimSubject;

    public void StartDamagedAnim(){
        actorAnimator.SetTrigger("DamagedAnimTrigger");
    }


    public void StartAttackAnim(E_ActionAnimTrigger triger){
        actorAnimator.SetTrigger(triger.ToString());
    }


    public void StartGetGoodStatusAnim(){
        actorAnimator.SetTrigger("GoodEffectTrigger");
    }


    public void StartGetBadStatusAnim(){
        actorAnimator.SetTrigger("BadEffectTrigger");
    }


    public void StartCureAnim(){
        actorAnimator.SetTrigger("CureAnimTrigger");
    }


    public void StartDeadAnim(){
        actorAnimator.SetTrigger("DeadAnimTrigger");
    }

    public void InitAnim(){
        actorAnimator.Play("Default");
    }


    public void FinishAnim(){
        finishAnimSubject.OnNext(Unit.Default);
    }
}
