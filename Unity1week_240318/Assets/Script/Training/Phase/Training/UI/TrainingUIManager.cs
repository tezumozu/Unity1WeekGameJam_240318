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

    private Subject<E_TrainingType> PushButtonSubject = new Subject<E_TrainingType>();
    public IObservable<E_TrainingType> PushButtonAsync => PushButtonSubject;

    private void Start(){

        gameManager.PauseAsync
        .Subscribe((flag)=>{
            gameObject.SetActive(!flag);
        })
        .AddTo(this);

        gameManager.GameStateAsync
        .Subscribe((state)=>{
            if(state == E_TrainingState.Training){
                gameObject.SetActive(true);
            }else{
                gameObject.SetActive(false);
            }
            
        })
        .AddTo(this);
    }

    public void PushTrainingButton(int type){
        PushButtonSubject.OnNext((E_TrainingType)type);
    }
}
