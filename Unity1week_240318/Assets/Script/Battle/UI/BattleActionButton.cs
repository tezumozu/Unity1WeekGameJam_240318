using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleActionButton : MonoBehaviour{
    [SerializeField]
    E_ActionType MyType;

    private Subject<E_ActionType> PushButtonSubject = new Subject<E_ActionType>();
    public IObservable<E_ActionType> PushButtonAsync => PushButtonSubject;

    public void OnClickButton(){
        PushButtonSubject.OnNext(MyType);
    }

    //タイプからボタンの名前とコストを書き換える
    public void SetButtonData (E_ActionType type){

    }
}
