using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class FinishPhaseUpdater : PhaseUpdater{

    BattleTextManager textManager;
    BlackOutManager blackOut;
    ActorAnimManager enemyAnime;
    ActorAnimManager playerAnime;

    bool isAnimFin;

    IDisposable blackOutDisposable;
    IDisposable enemyAnimDisposable;
    IDisposable playerAnimDisposable;

    public FinishPhaseUpdater(){
        textManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();

        blackOut = GameObject.Find("Canvas/BlackOutAnim").GetComponent<BlackOutManager>();
        blackOutDisposable = blackOut.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });

        playerAnime = GameObject.Find("Canvas/PlayerUI").GetComponent<ActorAnimManager>();
        playerAnimDisposable = playerAnime.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });

        enemyAnime = GameObject.Find("Canvas/EnemyUI").GetComponent<ActorAnimManager>();
        enemyAnimDisposable = enemyAnime.FinishAnimAsync.Subscribe((x)=>{
            isAnimFin = true;
        });
    }

    public override IEnumerator StartPhase (S_BattleDate data){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //プレイヤーが負けていたら
        if(data.Player.GetCurrentStatus.HP <= 0){

            //テキスト更新
            textManager.SetText(data.Player.GetCurrentStatus.Name + " は敗れてしまった......");

            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            FinishPhaseSubject.OnNext(data);
            yield break;
        }

        //勝利数を加算
        data.WinCount++;

        //クリアしたか？
        if(data.WinCount >= 5){
            textManager.SetText("ダンジョンクリア！");

            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            FinishPhaseSubject.OnNext(data);

            yield break;

        }

        textManager.SetText("モンスターをたおした！");

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        textManager.SetText("次の階層へ！");

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        //アニメーション終了待ち
        isAnimFin = false;
        blackOut.StartBlackOutAnim();

        while (!isAnimFin){
            yield return null;
        }

        textManager.SetText(" ");

        //アニメーションのリセット
        playerAnime.InitAnim();
        enemyAnime.InitAnim();

        FinishPhaseSubject.OnNext(data);
    }

    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        blackOutDisposable.Dispose();
        enemyAnimDisposable.Dispose();
        playerAnimDisposable.Dispose();
    }

}
