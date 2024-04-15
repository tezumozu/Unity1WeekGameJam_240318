using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Zenject;

public class FinishAnimUIManager : MonoBehaviour{
    [SerializeField]
    Animator FinishAnimator;

    [Inject]
    TrainingGameManager gameManager;

     [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField] 
    AudioClip FinishSE;

    bool isAnimFin;

    void Start(){

        //ポーズを監視
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            if(flag){
                FinishAnimator.SetFloat("MovingSpeed", 0.0f);
            }else{
                FinishAnimator.SetFloat("MovingSpeed", 1.0f);
            }
        })
        .AddTo(this);

        gameObject.SetActive(false);
    }



    public IEnumerator StartFinishAnim(){
        gameObject.SetActive(true);

        isAnimFin = false;

        FinishAnimator.SetTrigger("CountDownAnim");

        while(!isAnimFin){
            yield return false;
        }

        gameObject.SetActive(false);
        yield return true;
    }

    public void FinishAnim(){
        isAnimFin = true;
    }

    public void PlaySE(){
        soundPlayer.PlaySE(FinishSE);
        
    }
}
