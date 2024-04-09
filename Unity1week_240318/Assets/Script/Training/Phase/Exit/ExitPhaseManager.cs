using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class ExitPhaseManager : TrainingPhase{

    TextBoxManager textBox;
    ExitPhaseInput inputManager;

    public ExitPhaseManager (){

        var Canvas = GameObject.Find("Canvas");
        textBox = Canvas.transform.Find("TextBox").gameObject.GetComponent<TextBoxManager>();
        inputManager = GameObject.Find("Inputs/ExitPhaseInput").GetComponent<ExitPhaseInput>();

    }


    public override IEnumerator StartPhase(){

        var playerData = PlayerData.GetPlayerStatus;

        //テキスト
        textBox.SetActive(true);

        textBox.SetText("お疲れ様です！");

        var isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        textBox.SetText( playerData.Name + " ちゃん なんだか たくましく なりましたね！");

        isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        textBox.SetText( "おや！？" + playerData.Name + " ちゃん の様子が！！");

        isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }
        

        StateFinishSubject.OnNext(Unit.Default);
    }
}
