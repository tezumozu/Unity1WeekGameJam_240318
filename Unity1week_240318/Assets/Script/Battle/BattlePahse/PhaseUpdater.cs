using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class PhaseUpdater : IDisposable{
    protected Subject<Unit> FinishPhaseSubject;
    public IObservable<Unit> FinishPhaseAsync => FinishPhaseSubject;

    protected BattleUIManager uiManager;
    protected BattleInputManager inputManager;

    public PhaseUpdater(){
        uiManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleUIManager>();
        inputManager = GameObject.Find("BattleInputManager").GetComponent<BattleInputManager>();
        
        FinishPhaseSubject = new Subject<Unit>();
    }

    public abstract IEnumerator StartPhase(S_BattleDate data);
    public abstract void Dispose();
}
