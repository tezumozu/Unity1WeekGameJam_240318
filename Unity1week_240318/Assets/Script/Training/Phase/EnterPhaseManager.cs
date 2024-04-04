using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EnterPhaseManager : TrainingPhase{
    TextBoxManager textBox;
    InputNameManager inputNameManager;
    EnterPhaseInput inputManager;

    GameObject SlimeImage;

    public EnterPhaseManager(){
        var Canvas = GameObject.Find("Canvas");
        textBox = Canvas.transform.Find("TextBox").gameObject.GetComponent<TextBoxManager>();
        inputManager = GameObject.Find("Inputs/EnterPhaseInput").GetComponent<EnterPhaseInput>();
        inputNameManager = Canvas.transform.Find("NameInputUI").gameObject.GetComponent<InputNameManager>();
        SlimeImage = Canvas.transform.Find("Slime").gameObject;
    }

    public override IEnumerator StartPhase(){
        textBox.SetText("ようこそ！スライム育成所へ！");

        var isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        textBox.SetText("今回 あなた には スライム を 育成して");

        isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        textBox.SetText("ダンジョンクリア を 目指して もらいます！");

        isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        //スライム表示
        SlimeImage.SetActive(true);

        textBox.SetText("今回 育成する スライム は この子 です！");

        isInput = inputManager.WaitClickInput();

        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        //yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        textBox.SetText("まず は 名前 を 決めましょう！");

        isInput = inputManager.WaitClickInput();
        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }


        //名前を入力してもらう　入力待機
        var inputCoroutine = inputManager.WaitInputName();

        //UI切り替え
        textBox.SetActive(false);
        inputNameManager.SetActive(true);

        //入力待ち
        CoroutineHander.OrderStartCoroutine(inputCoroutine);
        while(String.IsNullOrWhiteSpace((string)inputCoroutine.Current)){
            yield return null;
        }

        var Name = (string)inputCoroutine.Current;

        inputNameManager.SetActive(false);
        textBox.SetActive(true);


        textBox.SetText("「 " + Name + " 」!   素敵な 名前 ですね!");

        isInput = inputManager.WaitClickInput();
        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        textBox.SetText("それでは 早速 育成 に 移りましょう！");

        isInput = inputManager.WaitClickInput();
        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }



        textBox.SetText("スライム の 成長期 は 1分間！");

        isInput = inputManager.WaitClickInput();
        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }


        textBox.SetText("短い時間 ですが 頑張って 育成 しましょう！");

        isInput = inputManager.WaitClickInput();
        //クリック待ち
        CoroutineHander.OrderStartCoroutine(isInput);
        while(!(bool)isInput.Current){
            yield return null;
        }

        StateFinishSubject.OnNext(Unit.Default);
    }
}
