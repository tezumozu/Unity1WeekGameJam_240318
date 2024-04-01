using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UniRx;


public class ResultUIManager : MonoBehaviour{

    private Subject<Unit> BackToTitleSubject = new Subject<Unit>();
    public IObservable<Unit> BackToTitleAsync => BackToTitleSubject;

    //Status
    [SerializeField]
    TextMeshProUGUI Name;
    [SerializeField]
    TextMeshProUGUI Level;
    [SerializeField]
    TextMeshProUGUI HP;
    [SerializeField]
    TextMeshProUGUI MP;
    [SerializeField]
    TextMeshProUGUI Attack;
    [SerializeField]
    TextMeshProUGUI Defense;
    [SerializeField]
    TextMeshProUGUI Speed;
    [SerializeField]
    TextMeshProUGUI Stamina;

    [SerializeField]
    Image PlayerImage;

    [SerializeField]
    ResultSkillListManager skillList;

    [SerializeField]
    TextMeshProUGUI floor;
    [SerializeField]
    TextMeshProUGUI takeTurn;

    [SerializeField]
    GameObject CheckDisitionUI;
    
    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    AudioClip desitionSE;

    [SerializeField]
    AudioClip cancelSE;

    private void Start(){
        BattleSceneManager.currentStateAsync.Subscribe((state)=>{
            if(state == E_BattleSceneState.Result){
                SetActive(true);
            }
        })
        .AddTo(this);

        BattleManager.battleFinisheAsync.Subscribe((battleResult) => {
            //データ読み込み
            var data = PlayerData.GetPlayerStatus;
            var list = PlayerData.GetPlayerSkillList;

            //スプライト読み込み
            var newSprite = Resources.Load<Sprite>( "BattleScene/ActorImage/" + ((int)data.Image).ToString() );
            if(newSprite is null) Debug.Log("No Image!");
            
            PlayerImage.sprite = newSprite;

            //不要なアセットをアンロード
            Resources.UnloadUnusedAssets();

            Name.text = data.Name;
            Level.text = data.Level.ToString();
            HP.text = data.HP.ToString();
            MP.text = data.MP.ToString();
            Attack.text = data.Attack.ToString();
            Defense.text = data.Defense.ToString();
            Speed.text = data.Speed.ToString();
            Stamina.text = data.Stamina.ToString();

            skillList.SetSkillList(list);

            floor.text = battleResult.WinCount.ToString();
            takeTurn.text = battleResult.TakeTurn.ToString();

        })
        .AddTo(this);

        SetActive(false);
    }

    private void SetActive(bool flag){
        gameObject.SetActive(flag);
    }

     public void OnPushBackToTitleButton(){
        soundPlayer.PlaySE(desitionSE);
        CheckDisitionUI.SetActive(true);
    }

    public void CanselBackToTitle(){
        soundPlayer.PlaySE(cancelSE);
        CheckDisitionUI.SetActive(false);
    }

    public void DisitionBackToTitle(){
        soundPlayer.PlaySE(desitionSE);
        BackToTitleSubject.OnNext(Unit.Default);
    }

}
