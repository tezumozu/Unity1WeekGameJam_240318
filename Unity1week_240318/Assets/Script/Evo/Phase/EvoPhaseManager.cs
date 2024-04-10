using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EvoPhaseManager : TrainingPhase{

    private EvoInputManager inputManager;
    private EvoAnimManager animManager;
    private TextBoxManager textBox;

    
    public EvoPhaseManager(){
        
        //UI取得
        var Canvas = GameObject.Find("Canvas");
        inputManager = GameObject.Find("EvoInputManager").GetComponent<EvoInputManager>();
        animManager = Canvas.transform.Find("Actors/Slime").gameObject.GetComponent<EvoAnimManager>();
        textBox = Canvas.transform.Find("TextBox").gameObject.GetComponent<TextBoxManager>();

    }

    public override IEnumerator StartPhase(){
        var playerData = PlayerData.GetPlayerStatus;
        animManager.SetEvoImage(playerData.Image);

        textBox.SetActive(true);
        textBox.SetText( "おや " + playerData.Name + " の様子が！" );

        var isFinish = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isFinish);

        while(!(bool)isFinish.Current){
            yield return null;
        }

        textBox.SetActive(false);


        //アニメーション終了待ち
        isFinish = animManager.StartAnim();
        CoroutineHander.OrderStartCoroutine(isFinish);
        while(!(bool)isFinish.Current){
            yield return null;
        }


        textBox.SetActive(true);
        textBox.SetText( playerData.Name + " が 進化した！" );

        isFinish= inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isFinish);
        while(!(bool)isFinish.Current){
            yield return null;
        }

        StateFinishSubject.OnNext(Unit.Default);
    }
}
