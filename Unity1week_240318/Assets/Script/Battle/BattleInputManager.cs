using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BattleInputManager : MonoBehaviour{

    private Subject<Unit> clickSubject = new Subject<Unit>();
    private Subject<Unit> escSubject = new Subject<Unit>();
    private Subject<E_ActionType> ActionUISubject = new Subject<E_ActionType>();
    private Subject<E_OptionType> OptionUISubject = new Subject<E_OptionType>();

    public IObservable<Unit> clickAsync => clickSubject;
    public IObservable<Unit> escAsync => escSubject;
    public IObservable<E_ActionType> ActionUIAsync => ActionUISubject;
    public IObservable<E_OptionType> OptionUIAsync => OptionUISubject;

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            clickSubject.OnNext(Unit.Default);
        }
    }
}
