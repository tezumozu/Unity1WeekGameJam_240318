using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class SlimeTrainingManager : IDisposable {

    private Subject<S_BattleActorStatus> definitionStatusSubject;
    public IObservable<S_BattleActorStatus> DefinitionStatusAsync => definitionStatusSubject;

    private S_SlimeTrainingData traningData;


    //Disposable
    private IDisposable gameManagerDisposable;
    private IDisposable inputDisposable;

    public SlimeTrainingManager (TrainingPhaseInput trainingInput,TrainingGameManager gameManager){

        definitionStatusSubject = new Subject<S_BattleActorStatus>();



        //初期データを読み込む
        //パスを生成
        var fileName = "BattleScene/PlayerInitData";
        //読み込む
        var InitData = Resources.Load<EnemyData>(fileName);

        if(InitData is null){
            Debug.Log("Load error! : PlayerData.GetPlayerSkill");
        }

        //UIマネージャの取得
        inputDisposable = trainingInput.PushButtonAsync
        .Subscribe((type) =>{
            trainingStatus(type);
        });

        //ゲームマネージャーを監視
        gameManagerDisposable = gameManager.GameStateAsync
        .Where(state => state == E_TrainingState.Exit)
        .Subscribe((state)=>{
            definitionStatus();
        });

    }



    private void trainingStatus(E_TrainingType tyep){

    }



    private void definitionStatus(){
        var Status = new S_BattleActorStatus();
    }


    public void Dispose(){
        gameManagerDisposable.Dispose();
        inputDisposable.Dispose();
    }

}
