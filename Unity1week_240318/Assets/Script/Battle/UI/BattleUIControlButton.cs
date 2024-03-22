using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleUIControlButton : MonoBehaviour{
    [SerializeField]
    E_BattleUIType MyType;

    private Subject<E_BattleUIType> PushButtonSubject = new Subject<E_BattleUIType>();
    public IObservable<E_BattleUIType> PushButtonAsync => PushButtonSubject;

    public void OnClickButton(){
        PushButtonSubject.OnNext(MyType);
    }
}
