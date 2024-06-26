using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class StartPhaseUpdater : PhaseUpdater{

    bool isAnimFin;

    DungeonInfoUIManager dungeonInfo;
    BlackOutManager blackOut;

    BattleTextManager textManager;

    IDisposable animFinDisposable;
    IDisposable blackOutDisposable;

    public StartPhaseUpdater(){
        dungeonInfo = GameObject.Find("Canvas/DungeonInfo").GetComponent<DungeonInfoUIManager>();
        animFinDisposable = dungeonInfo.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });

        blackOut = GameObject.Find("Canvas/BlackOutAnim").GetComponent<BlackOutManager>();
        blackOutDisposable = blackOut.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });

        textManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();
    }

    //Start時の演出処理
    public override IEnumerator StartPhase (S_BattleDate data){

        //StateUIの初期化
        //buff
        //StatusEffect


        string dungeonInfoText;
        if(data.WinCount + 1 >= 5){
            dungeonInfoText = "最終層";
        }else{
            dungeonInfoText = "第" + (data.WinCount + 1) + "層";
        }

        dungeonInfo.SetInfo(dungeonInfoText);

        //アニメーション終了待ち
        isAnimFin = false;
        blackOut.StartBlackInAnim();

        while (!isAnimFin){
            yield return null;
        }

        //アニメーション終了待ち
        isAnimFin = false;
        dungeonInfo.StartAnim();

        while (!isAnimFin){
            yield return null;
        }

        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //テキスト変更
        if(data.WinCount + 1 >= 5){
           textManager.SetText("ダンジョンのボス "+ "ドラゴン" + " が現れた！");
        }else{
            textManager.SetText("モンスターが現れた！");
        }

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        textManager.SetText(" ");

        FinishPhaseSubject.OnNext(data);
    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        animFinDisposable.Dispose();
        blackOutDisposable.Dispose();
    }
}
