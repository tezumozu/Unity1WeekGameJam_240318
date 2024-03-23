using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class StartPhaseUpdater : PhaseUpdater{

    bool isAnimFin;
    bool isClicked;
    DungeonInfoUIManager dungeonInfo;
    BattleTextManager textManager;

    IDisposable animFinDisposable;
    IDisposable clickDisposable;

    public StartPhaseUpdater(){
        dungeonInfo = GameObject.Find("Canvas/DungeonInfo").GetComponent<DungeonInfoUIManager>();
        animFinDisposable = dungeonInfo.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });

        textManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();
        
        clickDisposable = inputManager.clickAsync.Subscribe((x)=>{
            isClicked = true;
        });
    }

    //Start時の演出処理
    public override IEnumerator StartPhase (S_BattleDate data){
        string dungeonInfoText;
        if(data.WinCount + 1 >= 5){
            dungeonInfoText = "最終層";
        }else{
            dungeonInfoText = "第" + (data.WinCount + 1) + "層";
        }

        dungeonInfo.SetInfo(dungeonInfoText);

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
        isClicked = false;
        while(!isClicked){
            yield return null;
        }

        FinishPhaseSubject.OnNext(Unit.Default);
    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        animFinDisposable.Dispose();
        clickDisposable.Dispose();
    }
}
