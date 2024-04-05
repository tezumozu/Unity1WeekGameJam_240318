using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class ExitPhaseManager : TrainingPhase{
    public override IEnumerator StartPhase(){
        Debug.Log("Exit");

        //テキスト
        
        yield return null;
        StateFinishSubject.OnNext(Unit.Default);
    }
}
