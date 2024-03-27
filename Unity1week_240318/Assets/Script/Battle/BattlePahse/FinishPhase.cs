using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class FinishPhaseUpdater : PhaseUpdater{

    BattleTextManager textManager;
    BlackOutManager blackOut;

    bool isClicked;
    bool isAnimFin;

    IDisposable clickDisposable;
    IDisposable blackOutDisposable;

    public FinishPhaseUpdater(){
        textManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();

        clickDisposable = inputManager.clickAsync.Subscribe((x)=>{
            isClicked = true;
        });

        blackOut = GameObject.Find("Canvas/BlackOutAnim").GetComponent<BlackOutManager>();
        blackOutDisposable = blackOut.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });
    }

    public override IEnumerator StartPhase (S_BattleDate data){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //テキストを変更
        if(data.Player.GetCurrentStatus.HP > 0){
           textManager.SetText("モンスターを倒した！");
        }else{
            textManager.SetText("プレイヤーはたおれてしまった！");
        }

        //クリック待ちをする
        isClicked = false;
        while(!isClicked){
            yield return null;
        }

        //テキストを変更
        if(data.WinCount + 1 >= 5){
           textManager.SetText("ダンジョンクリア！");

            isClicked = false;
            while(!isClicked){
                yield return null;
            }

            FinishPhaseSubject.OnNext(Unit.Default);

            yield break;

        }else{
            textManager.SetText("次の階層へ！");
        }

        //クリック待ちをする
        isClicked = false;
        while(!isClicked){
            yield return null;
        }

        //アニメーション終了待ち
        isAnimFin = false;
        blackOut.StartBlackOutAnim();

        while (!isAnimFin){
            yield return null;
        }

        textManager.SetText("");

        FinishPhaseSubject.OnNext(Unit.Default);
    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        clickDisposable.Dispose();
        blackOutDisposable.Dispose();
    }

}
