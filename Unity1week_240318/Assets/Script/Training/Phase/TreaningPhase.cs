using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class TrainingPhase : IDisposable{

    protected Subject<Unit> StateFinishSubject;
    public IObservable<Unit> StateFinishAsync => StateFinishSubject;

    protected List<IDisposable> DisposeList;

    public TrainingPhase(){
        StateFinishSubject = new Subject<Unit>();
        DisposeList = new List<IDisposable>();
    }

    public abstract IEnumerator StartPhase();

    public virtual void Dispose(){
        foreach (var disposable in DisposeList){
            disposable.Dispose();
        }
    }
}
