using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EnterPhaseManager : TrainingPhase{
    TextBoxManager textBox;

    public EnterPhaseManager(){
        
    }

    public override IEnumerator StartPhase(){
        Debug.Log("Enter");

        //名前を入力してもらう　入力待機

        yield return null;
        StateFinishSubject.OnNext(Unit.Default);
    }
}
