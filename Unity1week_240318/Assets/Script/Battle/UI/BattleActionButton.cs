using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleActionButton : MonoBehaviour{
    [SerializeField]
    protected E_ActionType MyType;

    protected Subject<E_ActionType> PushButtonSubject = new Subject<E_ActionType>();
    public IObservable<E_ActionType> PushButtonAsync => PushButtonSubject;

    public virtual void OnClickButton(){
        PushButtonSubject.OnNext(MyType);
    }
}
