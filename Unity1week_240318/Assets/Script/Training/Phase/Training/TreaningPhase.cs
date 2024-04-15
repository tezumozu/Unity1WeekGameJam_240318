using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class TrainingPhase : IDisposable{

    protected Subject<Unit> StateFinishSubject;
    public IObservable<Unit> StateFinishAsync => StateFinishSubject;

    protected List<IDisposable> DisposeList;

    protected SoundPlayer soundPlayer;

    public TrainingPhase(){
        StateFinishSubject = new Subject<Unit>();
        DisposeList = new List<IDisposable>();

        soundPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<SoundPlayer>();
    }

    public abstract IEnumerator StartPhase();

    public virtual void Dispose(){
        foreach (var disposable in DisposeList){
            disposable.Dispose();
        }
    }
}
