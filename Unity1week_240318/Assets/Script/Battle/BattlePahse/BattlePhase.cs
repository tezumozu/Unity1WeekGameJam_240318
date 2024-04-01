using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattlePhaseUpdater : PhaseUpdater{

    private TurnUpdater[] turnList;
    private int turnCount = 0;
    private const int turnMaxCount = 2;
    private bool isFinishBattle;

    //dispos
    private readonly List<IDisposable> disposableList;

    public BattlePhaseUpdater (){
        turnList = new TurnUpdater[2];
        disposableList = new List<IDisposable>();
    }


    //戦闘開始
    public override IEnumerator StartPhase (S_BattleDate data){

        //終了フラグを初期化
        isFinishBattle = false;
        turnCount = 0;

        //もし配列に中身が入っていたら
        if(turnList[0] != null){
            Dispose();
        }

        //ターンを作成
        //素早さPlayer < Enemy 同じな場合はプレイヤーから
        if(data.Player.GetMaxStatus.Speed >= data.Enemy.GetMaxStatus.Speed){
            turnList[0] = new TurnUpdater(data.Player,data.Enemy);
            turnList[1] = new TurnUpdater(data.Enemy,data.Player);
        }else{
            turnList[0] = new TurnUpdater(data.Enemy,data.Player);
            turnList[1] = new TurnUpdater(data.Player,data.Enemy);
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
                data.TakeTurn++;
                if(isFinishBattle){
                    //戦闘を終了させる
                    FinishPhaseSubject.OnNext(data);
                }else{
                    turnCount++;
                    
                    turnCount = turnCount % turnMaxCount;
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
