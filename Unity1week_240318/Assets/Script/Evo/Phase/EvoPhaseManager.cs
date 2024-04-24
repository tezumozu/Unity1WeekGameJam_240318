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

        var EvoTextList = Resources.Load<EvoTypeTextList>("Evo/EvoTextData");
        List<string> EvoText = new List<string>();

        foreach (var item in EvoTextList.EvoTextList){
            if( item.Type == (E_EvoType)((int)playerData.Image) ){
                EvoText = item.TextList;
            }
        }

        EvoTextList = null;

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

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
        
        foreach (var text in EvoText){
            textBox.SetText(playerData.Name + " " + text);

            isFinish= inputManager.WaitClickInput();

            //クリック待ち
            CoroutineHander.OrderStartCoroutine(isFinish);
            while(!(bool)isFinish.Current){
                yield return null;
            }
        }


        textBox.SetText(playerData.Name + " は わざ を覚えた！");

        isFinish= inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isFinish);
        while(!(bool)isFinish.Current){
            yield return null;
        }

        
        textBox.SetText("これで 戦う準備は 整いました！");

        isFinish= inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isFinish);
        while(!(bool)isFinish.Current){
            yield return null;
        }


        textBox.SetText("さっそくダンジョンへ 向かいましょう！");

        isFinish= inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isFinish);
        while(!(bool)isFinish.Current){
            yield return null;
        }
        

        StateFinishSubject.OnNext(Unit.Default);
    }
}
