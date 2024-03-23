using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class PlayerTurnUpdater : TurnUpdater{

    private BattleActor player;
    private BattleActor enemy;
    
    bool isActinInputed;
    bool isFinished;

    E_ActionType currentAction;

    IDisposable actionInputedDisposable;
    IDisposable playerDeadDisposable;
    IDisposable enemyDeadDisposable;


    public PlayerTurnUpdater(BattleActor player,BattleActor enemy){
        this.player = player;
        this.enemy = enemy;

        isActinInputed = false;

        actionInputedDisposable = inputManager.ActionUIAsync.Subscribe((type)=>{
            currentAction = type;
            isActinInputed = true;
        });

        isFinished = false;

        //死亡判定
        playerDeadDisposable = player.isDeadAsync.Subscribe((x)=>{
            isFinished = true;
        });

        enemyDeadDisposable = enemy.isDeadAsync.Subscribe((x)=>{
            isFinished = true;
        });
    }


    public override IEnumerator StartTurn(){
        //UIを切り替える
        uiManager.ChangeUI(E_BattleUIType.MeinMenu);

        //入力待ちをする
        isActinInputed = false;
        while (!isActinInputed){
            yield return null;
        }

        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //状態異常タイプAをチェック（麻痺）
        var resultTextList = player.CheckBeforeStatusEffect();

        //テキスト変更
        foreach (var text in resultTextList){
            textManager.SetText(text);

            //クリック待ちをする
            isClicked = false;
            while(!isClicked){
                yield return null;
            }
        }


        //Actionを処理
        resultTextList = player.ActionBattleActor(currentAction,enemy);

        //テキスト変更
        foreach (var text in resultTextList){
            textManager.SetText(text);

            //クリック待ちをする
            isClicked = false;
            while(!isClicked){
                yield return null;
            }
        }


        //勝敗チェック
        if(isFinished){
            FinishTurnSubject.OnNext(Unit.Default);
            yield break;
        }


        //状態異常タイプBをチェック（毒、猛毒）
        resultTextList = player.CheckAfterStatusEffect();

        //テキスト変更
        foreach (var text in resultTextList){
            textManager.SetText(text);

            //クリック待ちをする
            isClicked = false;
            while(!isClicked){
                yield return null;
            }
        }

        //勝敗チェック
        if(isFinished){
            FinishTurnSubject.OnNext(Unit.Default);
            yield break;
        }


        //リフレッシュ、状態異常や騒動不可、バフの消失などフラグの修正
        resultTextList = player.RefreshBattleActor();

        //テキスト変更
        foreach (var text in resultTextList){
            textManager.SetText(text);

            //クリック待ちをする
            isClicked = false;
            while(!isClicked){
                yield return null;
            }
        }

        FinishTurnSubject.OnNext(Unit.Default);
    }

    public override void Dispose(){
        actionInputedDisposable.Dispose();
        playerDeadDisposable.Dispose();
        enemyDeadDisposable.Dispose();
        clickDisposable.Dispose();
    }
}
