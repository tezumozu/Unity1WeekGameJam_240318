using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class TurnUpdater : IDisposable{
    protected Subject<Unit> FinishTurnSubject;
    public IObservable<Unit> FinishTurnAsync => FinishTurnSubject;

    protected bool isClicked;

    protected BattleUIManager uiManager;
    protected BattleInputManager inputManager;
    protected BattleTextManager textManager;

    protected IDisposable clickDisposable;

    public TurnUpdater(){
        FinishTurnSubject = new Subject<Unit>();

        uiManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleUIManager>();
        inputManager = GameObject.Find("BattleInputManager").GetComponent<BattleInputManager>();
        textManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();

        isClicked = false;

        clickDisposable = inputManager.clickAsync.Subscribe((x)=>{
            isClicked = true;
        });
    }

    public abstract IEnumerator StartTurn();
    public abstract void Dispose();
}
