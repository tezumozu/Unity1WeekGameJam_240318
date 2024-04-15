using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class GrowUPAnimManager : MonoBehaviour{
    [SerializeField]
    GameObject EffectPrefub;

    [Inject]
    SlimeTrainingManager trainingManager;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip StautsSE;

    [SerializeField]
    AudioClip ExpSE;

    [SerializeField]
    AudioClip LevelSE;

    // Start is called before the first frame update
    void Start(){
        var trainingInput = GameObject.Find("TrainingPhaseInput").GetComponent<TrainingPhaseInput>();
        //UIマネージャの取得
        trainingInput.PushButtonAsync
        .Subscribe((type) =>{
            AppliyEffect(type);
        }).AddTo(this);

        //レベルアップを監視
        trainingManager.LevelUpAsync
        .Subscribe((_)=>{
            AppliyEffect();
        }).AddTo(this);
    }

    private void AppliyEffect(E_TrainingType type){

        var SE = StautsSE;

        string num = "";

        //各タイプに合わせてステータスを更新
        switch (type){

            case E_TrainingType.Exp:
                    num = "1";
                    SE = ExpSE;
                break;



            case E_TrainingType.HP:
                    num = "20";
                break;     



            case E_TrainingType.MP:
                    num = "3";
                break;    



            case E_TrainingType.Attack:
                    num = "3";
                break; 



            case E_TrainingType.Defense:
                    num = "3";
                break;    



            case E_TrainingType.Speed:
                    num = "3";
                break; 

        }

        //prefubを生成する
        var EffectObject = Instantiate(EffectPrefub);

        //文字をセット
        var EffectAnim = EffectObject.GetComponent<GrowUpAnim>();
        EffectAnim.SetEffectText(type.ToString(),num);

        //自身の子オブジェクトに追加する
        EffectObject.transform.SetParent(gameObject.transform,false);
        soundPlayer.PlaySE(SE);

    }

    private void AppliyEffect(){
        //prefubを生成する
        var EffectObject = Instantiate(EffectPrefub);

        //文字をセット
        var EffectAnim = EffectObject.GetComponent<GrowUpAnim>();
        EffectAnim.SetEffectText("Level" , "1");

        //自身の子オブジェクトに追加する
        EffectObject.transform.SetParent(gameObject.transform,false);
        soundPlayer.PlaySE(LevelSE);
    }
}
