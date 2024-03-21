using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class TurnUpdater : IDisposable{
    protected Subject<Unit> FinishTurnSubject;
    public IObservable<Unit> FinishTurnAsync => FinishTurnSubject;

    public TurnUpdater(){
        FinishTurnSubject = new Subject<Unit>();
    }

    public abstract IEnumerator StartTurn();
    public abstract void Dispose();
}
