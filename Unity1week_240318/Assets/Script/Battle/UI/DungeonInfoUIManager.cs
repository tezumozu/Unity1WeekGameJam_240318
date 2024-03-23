using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class DungeonInfoUIManager : MonoBehaviour{
    private Animator animator;

    [SerializeField]
    private Text dungeonInfo; 

    private Subject<Unit> FinishAnimSubject = new Subject<Unit>();
    public IObservable<Unit> FinishAnimAsync => FinishAnimSubject;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
    }

    public void StartAnim(){
        gameObject.SetActive(true);
        animator.SetTrigger("StartEffectTrigger");
    }

    public void SetInfo(string text){
        dungeonInfo.text = text;
    }

    public void FinishAnim(){
        FinishAnimSubject.OnNext(Unit.Default);
        gameObject.SetActive(false);
    }
}
