using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using Zenject;


public class SlimeTrainingManager : IDisposable {

    private Subject<S_BattleActorStatus> definitionStatusSubject = new Subject<S_BattleActorStatus>();
    public IObservable<S_BattleActorStatus> DefinitionStatusAsync => definitionStatusSubject;

    private Subject<List<E_ActionType>> definitionSkillSubject = new Subject<List<E_ActionType>>();
    public IObservable<List<E_ActionType>> DefinitioSkillAsync => definitionSkillSubject;

    private Subject<S_SlimeTrainingData> UpdateTrainingStatusSubject = new Subject<S_SlimeTrainingData>();
    public IObservable<S_SlimeTrainingData> UpdateTrainingStatusAsync => UpdateTrainingStatusSubject;

    private Subject<Unit> LevelUpSubject = new Subject<Unit>();
    public IObservable<Unit> LevelUpAsync => LevelUpSubject;

    private S_SlimeTrainingData trainingData;
    private string name;

    //Disposable
    private IDisposable gameManagerDisposable;
    private IDisposable inputDisposable;
    private IDisposable nameInputDisposable;

    private StatusTable statusTable;


    [Inject]
    public SlimeTrainingManager (TrainingGameManager gameManager){

        //ステータステーブルを取得
        //パスを生成
        var fileName = "TrainingScene/StatusTableData";
        //読み込む
        statusTable = Resources.Load<StatusTable>(fileName);

        if(statusTable is null){
            Debug.Log("Load error! : PlayerData.GetPlayerSkill");
        }

        //InputManagerの取得
        var trainingInput = GameObject.Find("TrainingPhaseInput").GetComponent<TrainingPhaseInput>();

        //初期データを読み込む
        //パスを生成
        fileName = "BattleScene/PlayerInitData";
        //読み込む
        var resultStatus = Resources.Load<EnemyData>(fileName).EnemyStatus;

        if(resultStatus.Level == 0){
            Debug.Log("Load error! : PlayerData.GetPlayerSkill");
        }

        //初期化
        trainingData = new S_SlimeTrainingData(resultStatus,statusTable);

        var Canvas = GameObject.Find("Canvas");
        var inputNameManager = Canvas.transform.Find("NameInputUI").gameObject.GetComponent<InputNameManager>(); 
        nameInputDisposable = inputNameManager.InputNameAsync
        .Subscribe((input) => {
            name = input;
        });

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

        //ゲームマネージャーを監視
        gameManagerDisposable = gameManager.GameStateAsync
        .Where(state => state == E_TrainingState.Training)
        .Subscribe((state)=>{
            UpdateTrainingStatusSubject.OnNext(trainingData);
        });
    }



    private void trainingStatus(E_TrainingType tyep){

        //各タイプに合わせてステータスを更新
        switch (tyep){

            case E_TrainingType.Exp:
                //レベルが最大なら
                if(trainingData.Level >= 100) return;

                //経験値を獲得する
                trainingData.CurrentExp += 1;
                
                //レベルアップを確認
                if(statusTable.NeedExp[trainingData.Level-1] == trainingData.CurrentExp){
                    trainingData.CurrentExp = 0;
                    trainingData.SkillPoint += statusTable.SkillPointTable[trainingData.Level-1];
                    trainingData.HP += statusTable.LevelUpHPGrow;
                    trainingData.MP += statusTable.LevelUpMPGrow;
                    trainingData.Attack += statusTable.LevelUpAttackGrow;
                    trainingData.Defense += statusTable.LevelUpDefenseGrow;
                    trainingData.Speed += statusTable.LevelUpSpeedGrow;
                    trainingData.Level += 1;

                    if(trainingData.Level != 100){
                        trainingData.MaxExp = statusTable.NeedExp[trainingData.Level-1];
                        LevelUpSubject.OnNext(Unit.Default);
                    }
                }

                break;



            case E_TrainingType.HP:

                //ポイントが足りなければ
                if(trainingData.SkillPoint < 1.0f) return;
                //レベルが最大なら
                if(trainingData.HPLevel >= 100) return;
                
                //ポイントを減少させる
                trainingData.SkillPoint -= 1;

                //レベルを上げる
                trainingData.HPLevel += 1;
                trainingData.HP += statusTable.StatusUpHPGrow;

                break;     



            case E_TrainingType.MP:

                //ポイントが足りなければ
                if(trainingData.SkillPoint < 1.0f) return;
                //レベルが最大なら
                if(trainingData.MPLevel >= 100) return;
                
                //ポイントを減少させる
                trainingData.SkillPoint -= 1;

                //レベルを上げる
                trainingData.MPLevel += 1;
                trainingData.MP += statusTable.StatusUpMPGrow;

                break;    



            case E_TrainingType.Attack:

                //ポイントが足りなければ
                if(trainingData.SkillPoint < 1.0f) return;
                //レベルが最大なら
                if(trainingData.AttackLevel >= 100) return;
                
                //ポイントを減少させる
                trainingData.SkillPoint -= 1;

                //レベルを上げる
                trainingData.AttackLevel += 1;
                trainingData.Attack += statusTable.StatusUpAttackGrow;

                break; 



            case E_TrainingType.Defense:

                //ポイントが足りなければ
                if(trainingData.SkillPoint < 1.0f) return;
                //レベルが最大なら
                if(trainingData.DefenseLevel >= 100) return;
                
                //ポイントを減少させる
                trainingData.SkillPoint -= 1;

                //レベルを上げる
                trainingData.DefenseLevel += 1;
                trainingData.Defense += statusTable.StatusUpDefenseGrow;

                break;    



            case E_TrainingType.Speed:

                //ポイントが足りなければ
                if(trainingData.SkillPoint < 1.0f) return;
                //レベルが最大なら
                if(trainingData.SpeedLevel >= 100) return;
                
                //ポイントを減少させる
                trainingData.SkillPoint -= 1;

                //レベルを上げる
                trainingData.SpeedLevel += 1;
                trainingData.Speed += statusTable.StatusUpSpeedGrow;

                break; 

        }

        UpdateTrainingStatusSubject.OnNext(trainingData);
    }



    private void definitionStatus(){

        //ステータス変化によるスキルリストの作成

        var styleChecker = new EvoStyleChecker();
        EvoStyle style = styleChecker.CheckEvolve(trainingData);
        var resultStatus = style.GetStatus(trainingData);
        List<E_ActionType> skillList = style.GetLearningSkill(trainingData);

        //どのスライムになるか確定
        resultStatus.Name = name;


        //確定したステータスを通知
        definitionStatusSubject.OnNext(resultStatus);

        //確定したスキルリストを通知
        definitionSkillSubject.OnNext(skillList);
    }



    public void UpdateStatus(){
        
    }


    public void Dispose(){
        gameManagerDisposable.Dispose();
        inputDisposable.Dispose();
        nameInputDisposable.Dispose();
    }
}
