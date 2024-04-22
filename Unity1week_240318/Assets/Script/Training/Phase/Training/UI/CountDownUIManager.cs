using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UniRx;
using Zenject;

public class CountDownUIManager : MonoBehaviour{

    [SerializeField]
    Image CountDownImage;

    [SerializeField]
    List<Sprite> CountDownSprite;

    [SerializeField]
    Animator CountDownAnim;

    [Inject]
    TrainingGameManager gameManager;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField] 
    AudioClip CountDownSE;

    [SerializeField] 
    AudioClip StartSE;

    int count;



    bool isAnimFin;

    void Start(){
        count = 0;

        //ポーズを監視
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            if(flag){
                CountDownAnim.SetFloat("MoveSpeed", 0.0f);
            }else{
                CountDownAnim.SetFloat("MoveSpeed", 1.0f);
            }
        })
        .AddTo(this);

        gameObject.SetActive(false);
    }



    public IEnumerator StartCountDown(){
        gameObject.SetActive(true);

        for (int i = 0; i < CountDownSprite.Count; i++){
            count = i;
            //SEを鳴らす

            isAnimFin = false;
            CountDownImage.sprite = CountDownSprite[i];

            CountDownAnim.SetTrigger("CountDownAnim");
            while(!isAnimFin){
                yield return false;
            }
        }

        gameObject.SetActive(false);
        yield return true;
    }

    public void FinishAnim(){
        isAnimFin = true;
    }

    public void PlaySE(){
        //スタートなら
        if(count == CountDownSprite.Count-1){
            soundPlayer.PlaySE(StartSE);
        }else{
            soundPlayer.PlaySE(CountDownSE);
        }
    }

}
