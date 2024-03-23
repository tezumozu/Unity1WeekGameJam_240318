using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EnemyTurnUpdater : TurnUpdater{

    private BattleActor player;
    private BattleActor enemy;

    private E_ActionType currentAction;

    private bool isFinished;

    IDisposable playerDeadDisposable;
    IDisposable enemyDeadDisposable;

    public EnemyTurnUpdater(BattleActor player,BattleActor enemy){
        this.player = player;
        this.enemy = enemy;

        //死亡判定
        playerDeadDisposable = player.isDeadAsync.Subscribe((x)=>{
            isFinished = true;
        });

        enemyDeadDisposable = enemy.isDeadAsync.Subscribe((x)=>{
            isFinished = true;
        });

        isFinished = false;
    }


    public override IEnumerator StartTurn(){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //状態異常タイプAをチェック（麻痺）
        var resultTextList = enemy.CheckBeforeStatusEffect();

        //テキスト変更
        foreach (var text in resultTextList){
            textManager.SetText(text);

            //クリック待ちをする
            isClicked = false;
            while(!isClicked){
                yield return null;
            }
        }


        //Actionをランダムに取得
        var skillList = enemy.GetSkillList;
        int rnd = UnityEngine.Random.Range(1, skillList.Count);
        currentAction = skillList[rnd];

        //Actionを処理
        resultTextList = enemy.ActionBattleActor(currentAction,player);

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
        resultTextList = enemy.CheckAfterStatusEffect();

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
        resultTextList = enemy.RefreshBattleActor();

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
        playerDeadDisposable.Dispose();
        enemyDeadDisposable.Dispose();
        clickDisposable.Dispose();
    }
}
