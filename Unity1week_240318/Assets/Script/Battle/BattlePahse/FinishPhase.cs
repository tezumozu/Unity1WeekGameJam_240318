using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class FinishPhaseUpdater : PhaseUpdater{

    BattleTextManager textManager;

    bool isClicked;

    IDisposable clickDisposable;

    public FinishPhaseUpdater(){
        textManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();

        clickDisposable = inputManager.clickAsync.Subscribe((x)=>{
            isClicked = true;
        });
    }

    public override IEnumerator StartPhase (S_BattleDate data){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //テキストを変更
        if(data.Player.GetCurrentStatus.HP > 0){
           textManager.SetText("プレイヤーの勝利！");
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
        }else{
            textManager.SetText("次の階層へ！");
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
        clickDisposable.Dispose();
    }

}
