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

    public void SetResult(S_BattleActorStatus data , List<E_ActionType> list, int ClearFloor , int TakeTurn){
        //スプライト読み込み

        Name.text = data.Name;
        Level.text = data.Level.ToString();
        HP.text = data.HP.ToString();
        MP.text = data.MP.ToString();
        Attack.text = data.Attack.ToString();
        Defense.text = data.Defense.ToString();
        Speed.text = data.Speed.ToString();
        Stamina.text = data.Stamina.ToString();

        skillList.SetSkillList(list);

        floor.text = ClearFloor.ToString();
        takeTurn.text = TakeTurn.ToString();
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);
    }

     public void OnPushBackToTitleButton(){
        CheckDisitionUI.SetActive(true);
    }

    public void CanselBackToTitle(){
        CheckDisitionUI.SetActive(false);
    }

    public void DisitionBackToTitle(){
        BackToTitleSubject.OnNext(Unit.Default);
    }

}
