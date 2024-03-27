using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleManager : IDisposable{

    private Dictionary<E_BattlePhase,PhaseUpdater> pahseDic;
    private int winCount;
    private readonly int maxWinCount;
    private PlayerBattleActor playerActor;
    private EnemyBattleActor enemyActor;
    private S_BattleDate currentBattleData;
    private ResultUIManager resultUIManager;

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
        disposableList = new List<IDisposable>();
        resultUIManager = GameObject.Find("Canvas/ResultUI").GetComponent<ResultUIManager>();

        //Dic初期化
        pahseDic[E_BattlePhase.StartPhase] = new StartPhaseUpdater();
        pahseDic[E_BattlePhase.BattlePhase] = new BattlePhaseUpdater();
        pahseDic[E_BattlePhase.FinishPhase] = new FinishPhaseUpdater();

        playerActor = new PlayerBattleActor(new ActionFactory(),new BuffFactory(),new StatusEffectFactory());

        //最初のエネミーを生成
        enemyActor = new EnemyBattleActor(E_EnemyType.TestEnemy,new ActionFactory(),new BuffFactory(),new StatusEffectFactory());


        currentBattleData = new S_BattleDate(winCount,playerActor,enemyActor);
    }


    public void StartBattle(){

        //コルーチン終了時
        var disopsable = pahseDic[E_BattlePhase.StartPhase].FinishPhaseAsync.Subscribe((x)=>{
            currentPhase.Value = E_BattlePhase.BattlePhase;
        });


        disposableList.Add(disopsable);


        disopsable = pahseDic[E_BattlePhase.BattlePhase].FinishPhaseAsync.Subscribe((x)=>{
            currentPhase.Value = E_BattlePhase.FinishPhase;
        });

        disposableList.Add(disopsable);
        


        disopsable = pahseDic[E_BattlePhase.FinishPhase].FinishPhaseAsync.Subscribe((x)=>{
            Debug.Log("Finish終了");
            //もしプレイヤーが勝利したら
            if(playerActor.GetCurrentStatus.HP > 0){

                //勝利回数を加算
                winCount++;
                //全ての勝負に勝利しているか
                if(winCount == maxWinCount){
                   //バトル終了
                   battleFinisheSubject.OnNext(Unit.Default);
                   resultUIManager.SetResult(playerActor.GetMaxStatus , playerActor.GetSkillList , winCount , pahseDic[E_BattlePhase.BattlePhase].TakeTurnCount);
                }else{

                    enemyActor.Dispose();

                    //次のエネミーを生成
                    enemyActor = new EnemyBattleActor(E_EnemyType.TestEnemy,new ActionFactory(),new BuffFactory(),new StatusEffectFactory());

                    //プレイヤーの状態を回復
                    playerActor.ResetState();

                    //新しいバトルデータを生成、次のバトルへ
                    currentBattleData = new S_BattleDate(winCount,playerActor,enemyActor);
                    currentPhase.Value = E_BattlePhase.StartPhase;
                }

            }else{
                //バトル終了
                battleFinisheSubject.OnNext(Unit.Default);
            }

            //リソースを開放
            Resources.UnloadUnusedAssets();
        });

        disposableList.Add(disopsable);


        //なぜか値が勝手に代入される（なぜ？）
        disopsable = currentPhase.Subscribe((x)=>{
            CoroutineHander.OrderStartCoroutine(pahseDic[x].StartPhase(currentBattleData));
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

        playerActor.Dispose();
        enemyActor.Dispose();
    }

}
