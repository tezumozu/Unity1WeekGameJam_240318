using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleManager : IDisposable{

    private Dictionary<E_BattlePhase,PhaseUpdater> pahseDic;
    private int winCount;
    private readonly int maxWinCount;
    private BattleActor playerData;
    private S_BattleDate currentBattleData;

    //Subjects
    private ReactiveProperty<E_BattlePhase> currentPhase;
    private Subject<Unit> battleFinisheSubject;

    public IObservable<Unit> battleFinisheAsync => battleFinisheSubject;

    //dispos
    private readonly List<IDisposable> disposableList;


    public BattleManager (){
        currentPhase = new ReactiveProperty<E_BattlePhase>();
        pahseDic = new Dictionary<E_BattlePhase,PhaseUpdater>();
        battleFinisheSubject = new Subject<Unit>();
        winCount = 0;
        maxWinCount = 5;
        playerData = new BattleActor(new S_BattleActorStatus(10,10,10,10,10));
        currentBattleData = new S_BattleDate(winCount,playerData,new BattleActor(new S_BattleActorStatus(10,10,10,10,10)));
        disposableList = new List<IDisposable>();

        //Dic初期化
        pahseDic[E_BattlePhase.StartPhase] = new StartPhase();
        pahseDic[E_BattlePhase.BattlePhase] = new BattlePhase();
        pahseDic[E_BattlePhase.FinishPhase] = new FinishPhase();
    }


    public void StartBattle(){

        //コルーチン終了時
        var disopsable = pahseDic[E_BattlePhase.StartPhase].FinishPhaseAsync.Subscribe((x)=>{
            Debug.Log("Start終了");
            currentPhase.Value = E_BattlePhase.BattlePhase;
        });


        disposableList.Add(disopsable);


        disopsable = pahseDic[E_BattlePhase.BattlePhase].FinishPhaseAsync.Subscribe((x)=>{
            Debug.Log("Battle終了");
            currentPhase.Value = E_BattlePhase.FinishPhase;
        });

        disposableList.Add(disopsable);
        


        disopsable = pahseDic[E_BattlePhase.FinishPhase].FinishPhaseAsync.Subscribe((x)=>{
            Debug.Log("Finish終了");
            //もしプレイヤーが勝利したら
            if(true){

                //勝利回数を加算
                winCount++;
                //全ての勝負に勝利していないなら
                if(winCount == maxWinCount){
                   //バトル終了
                   battleFinisheSubject.OnNext(Unit.Default);
                }else{
                     //新しいバトルデータを生成、次のバトルへ
                    currentBattleData = new S_BattleDate(winCount,playerData,new BattleActor(new S_BattleActorStatus(10,10,10,10,10)));
                    currentPhase.Value = E_BattlePhase.StartPhase;
                }

            }else{
                //バトル終了
                battleFinisheSubject.OnNext(Unit.Default);
            }
        });

        disposableList.Add(disopsable);


        //なぜか値が勝手に代入される（なぜ？）
        disopsable = currentPhase.Subscribe((x)=>{
            Debug.Log(x+" 呼び出し");
            CoroutineHander.OrderStartCoroutine(pahseDic[x].StartUpdatePhase(currentBattleData));
        });

        disposableList.Add(disopsable);

        //コルーチンを起動
        //currentPhase.Value = E_BattlePhase.StartPhase;
    }



    // このクラスがDisposeされたら購読も止める
    public void Dispose(){
        foreach (var disopsable in disposableList){
            disopsable.Dispose();
        }

        foreach (var disopsable in pahseDic){
            disopsable.Value.Dispose();
        }
    }

}
