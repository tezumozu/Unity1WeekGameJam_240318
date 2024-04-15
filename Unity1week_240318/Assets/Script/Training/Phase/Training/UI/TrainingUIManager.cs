using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using Zenject;

public class TrainingUIManager : MonoBehaviour{

    [SerializeField]
    TrainingTimer timer;

    [Inject]
    TrainingGameManager gameManager;

    bool isActiveState;

    private Subject<E_TrainingType> PushButtonSubject = new Subject<E_TrainingType>();
    public IObservable<E_TrainingType> PushButtonAsync => PushButtonSubject;

    private void Start(){

        isActiveState = false;

        gameManager.PauseAsync
        .Subscribe((flag)=>{
            if (isActiveState){
                gameObject.SetActive(!flag);
            }else{
                //念のため
                gameObject.SetActive(false);
            }
        })
        .AddTo(this);

        gameManager.GameStateAsync
        .Subscribe((state)=>{
            if(state == E_TrainingState.Training){
                isActiveState = true;
                gameObject.SetActive(true);
            }else{
                isActiveState = false;
                gameObject.SetActive(false);
            }
            
        })
        .AddTo(this);
    }

    public void PushTrainingButton(int type){
        PushButtonSubject.OnNext((E_TrainingType)type);
    }
}
