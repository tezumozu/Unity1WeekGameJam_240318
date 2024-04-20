using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class BattleManager : IDisposable{

    private Dictionary<E_BattlePhase,PhaseUpdater> pahseDic;
    private readonly int maxWinCount;
    private PlayerBattleActor playerActor;
    private BattleActor enemyActor;
    private S_BattleDate currentBattleData;
    private DungeonData currentDungeonData;
    private bool isPlayerLose;
    private SoundPlayer BGMManager;
    private Image BG;
    private I_EnemyCreatable enemyFactory;

    //Subjects
    private ReactiveProperty<E_BattlePhase> currentPhase;
    private static Subject<S_BattleDate> battleFinisheSubject = new Subject<S_BattleDate>();

    public static IObservable<S_BattleDate> battleFinisheAsync => battleFinisheSubject;

    //dispos
    private readonly List<IDisposable> disposableList;


    public BattleManager (I_EnemyCreatable enemyFactory){
        currentPhase = new ReactiveProperty<E_BattlePhase>();
        pahseDic = new Dictionary<E_BattlePhase,PhaseUpdater>();
        maxWinCount = 5;
        disposableList = new List<IDisposable>();

        this.enemyFactory = enemyFactory;

        //Dic初期化
        pahseDic[E_BattlePhase.StartPhase] = new StartPhaseUpdater();
        pahseDic[E_BattlePhase.BattlePhase] = new BattlePhaseUpdater();
        pahseDic[E_BattlePhase.FinishPhase] = new FinishPhaseUpdater();

        BGMManager = GameObject.Find("BGMSoundPlayer").GetComponent<SoundPlayer>();
        BG = GameObject.Find("Canvas/BackGround").GetComponent<Image>();

        playerActor = new PlayerBattleActor(new ActionFactory(),new BuffFactory(),new StatusEffectFactory());

        //ダンジョンデータの読み込み
        var path = "BattleScene/DungeonData/" + ((E_DungeonFloor)0).ToString();
        currentDungeonData = Resources.Load<DungeonData>(path);

        //最初ののエネミーを生成
        enemyActor = enemyFactory.CreateEnemy(currentDungeonData.Enemy);

        currentBattleData = new S_BattleDate(0,0,playerActor,enemyActor);
    }


    public void StartBattle(){

        //各フェーズの終了を監視
        //Start
        var disopsable = pahseDic[E_BattlePhase.StartPhase].FinishPhaseAsync.Subscribe((data)=>{
            currentBattleData = data;
            currentPhase.Value = E_BattlePhase.BattlePhase;
        });

        disposableList.Add(disopsable);


        //Battle
        disopsable = pahseDic[E_BattlePhase.BattlePhase].FinishPhaseAsync.Subscribe((data)=>{
            string path;
            if(isPlayerLose){
                //敗北BGMを流す
                path = "Sound/Battle/BGM/Lose";
                var BGM = Resources.Load<AudioClip>(path);
                BGMManager.PlayBGM(BGM); 

            }else{
                //勝利BGMを流す
                //ダンジョンデータの読み込み
                path = "Sound/Battle/BGM/Win"; 
                var BGM = Resources.Load<AudioClip>(path);
                BGMManager.PlayBGM( BGM , false ); 
            } 

            //必要ないものをアンロード
            Resources.UnloadUnusedAssets();

            currentBattleData = data;
            currentPhase.Value = E_BattlePhase.FinishPhase;
        });

        disposableList.Add(disopsable);


        //Finish
        disopsable = pahseDic[E_BattlePhase.FinishPhase].FinishPhaseAsync.Subscribe((data)=>{
            currentBattleData = data;

            //もしプレイヤーが負けたら
            if(isPlayerLose){
                //バトル終了
                battleFinisheSubject.OnNext(currentBattleData);
                return;
            }

            //全ての勝負に勝利しているか
            if(data.WinCount == maxWinCount){
                battleFinisheSubject.OnNext(currentBattleData);
            }else{

                enemyActor.Dispose();

                //ダンジョンデータの読み込み
                var path = "BattleScene/DungeonData/" + ((E_DungeonFloor)data.WinCount).ToString();
                currentDungeonData = Resources.Load<DungeonData>(path);

                //次のエネミーを生成
                enemyActor = enemyFactory.CreateEnemy(currentDungeonData.Enemy);

                //プレイヤーの状態を回復
                playerActor.ResetState();

                //BGM再生
                BGMManager.PlayBGM(currentDungeonData.BGM);

                //背景を変更
                BG.sprite = currentDungeonData.BG;

                //必要ないものをアンロード
                Resources.UnloadUnusedAssets();

                //新しいバトルデータを生成、次のバトルへ
                currentBattleData = new S_BattleDate(currentBattleData.WinCount,currentBattleData.TakeTurn,playerActor,enemyActor);
                currentPhase.Value = E_BattlePhase.StartPhase;
            }
        });

        disposableList.Add(disopsable);


        //値が勝手に代入される（初期値が0でその分が走っているっぽい）
        disopsable = currentPhase.Subscribe((x)=>{
            CoroutineHander.OrderStartCoroutine(pahseDic[x].StartPhase(currentBattleData));
        });

        disposableList.Add(disopsable);

        //敗北を監視
        isPlayerLose = false;
        disopsable = playerActor.isDeadAsync.Subscribe((_)=>{
            isPlayerLose = true;
        });

        disposableList.Add(disopsable);

        //BGM再生
        BGMManager.PlayBGM(currentDungeonData.BGM);

        //背景を変更
        BG.sprite = currentDungeonData.BG;

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
