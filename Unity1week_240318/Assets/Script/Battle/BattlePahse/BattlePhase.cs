using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattlePhase : PhaseUpdater{

    private TurnUpdater[] turnList;
    private int turnCount = 0;
    private const int turnMaxCount = 4;
    private bool isFinishBattle;

    //dispos
    private readonly List<IDisposable> disposableList;



    public BattlePhase (){
        turnList = new TurnUpdater[4];
        disposableList = new List<IDisposable>();
    }



    //戦闘開始
    public override IEnumerator StartUpdatePhase (S_BattleDate data){

        Debug.Log("戦闘開始");

        //終了フラグを初期化
        isFinishBattle = false;
        turnCount = 0;

        //もし配列に中身が入っていたら
        if(true){
            Dispose();
        }

        //ターンを作成
        //素早さPlayer < Enemy 同じな場合はプレイヤーから
        if(data.Player.GetMaxStatus.Speed >= data.Enemy.GetMaxStatus.Speed){
            turnList[0] = new PlayerTurnUpdater(data.Player,data.Enemy);
            turnList[1] = new StateCheckTurnUpdater(data.Player);
            turnList[2] = new EnemyTurnUpdater(data.Enemy,data.Player);
            turnList[3] = new StateCheckTurnUpdater(data.Enemy);
        }else{
            turnList[0] = new EnemyTurnUpdater(data.Enemy,data.Player);
            turnList[1] = new StateCheckTurnUpdater(data.Enemy);
            turnList[2] = new PlayerTurnUpdater(data.Player,data.Enemy);
            turnList[3] = new StateCheckTurnUpdater(data.Player);
        }


        //モンスターやプレイヤーの敗北を監視
            //プレイヤー
        var disposable = data.Player.isDeadAsync.Subscribe((x)=>{
            isFinishBattle = true;
        });

        disposableList.Add(disposable);


            //モンスター
        disposable = data.Enemy.isDeadAsync.Subscribe((x)=>{
            isFinishBattle = true;
        });

        disposableList.Add(disposable);


        //各ターンの終了を監視
        for (int i = 0; i < turnMaxCount; i++){
           disposable = turnList[i].FinishTurnAsync.Subscribe((x)=>{
                if(isFinishBattle){
                    Debug.Log("戦闘終了");
                    //戦闘を終了させる
                    FinishPhaseSubject.OnNext(Unit.Default);
                }else{
                    turnCount++;
                    turnCount = turnCount%turnMaxCount;
                    CoroutineHander.OrderStartCoroutine(turnList[turnCount].StartTurn());
                }
            });      

            disposableList.Add(disposable);   
        }

        //バトルを開始する
        CoroutineHander.OrderStartCoroutine(turnList[turnCount].StartTurn());

        yield return null;
    }



    // このクラスがDisposeされたら購読も止める
    public override void Dispose(){
        foreach (var disopsable in disposableList){
            disopsable.Dispose();
        }

        foreach (var disopsable in turnList){
            if(disopsable is null) return;
            disopsable.Dispose();
        }

        //リストを空にする
        disposableList.Clear();
    }

}
