using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class PhaseUpdater : IDisposable{
    protected Subject<Unit> FinishPhaseSubject;
    public IObservable<Unit> FinishPhaseAsync => FinishPhaseSubject;

    public PhaseUpdater(){
        FinishPhaseSubject = new Subject<Unit>();
    }

    public abstract IEnumerator UpdatePhase(S_BattleDate data);
    public abstract void Dispose();
}
