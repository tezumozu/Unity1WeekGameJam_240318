using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class PhaseUpdater : IDisposable{
    protected Subject<S_BattleDate> FinishPhaseSubject;
    public IObservable<S_BattleDate> FinishPhaseAsync => FinishPhaseSubject;

    protected BattleUIManager uiManager;
    protected BattleInputManager inputManager;

    public PhaseUpdater(){
        uiManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleUIManager>();
        inputManager = GameObject.Find("BattleInputManager").GetComponent<BattleInputManager>();
        
        FinishPhaseSubject = new Subject<S_BattleDate>();
    }

    public abstract IEnumerator StartPhase(S_BattleDate data);
    public abstract void Dispose();
}
