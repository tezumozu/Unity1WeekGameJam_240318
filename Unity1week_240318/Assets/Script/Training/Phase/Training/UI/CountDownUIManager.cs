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

    bool isAnimFin;

    void Start(){

        //ポーズを監視
        gameManager.PauseAsync
        .Subscribe((flag)=>{
            if(flag){
                CountDownAnim.SetFloat("MovingSpeed", 0.0f);
            }else{
                CountDownAnim.SetFloat("MovingSpeed", 1.0f);
            }
        })
        .AddTo(this);

        gameObject.SetActive(false);
    }



    public IEnumerator StartCountDown(){
        gameObject.SetActive(true);

        for (int i = 0; i < CountDownSprite.Count; i++){
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

}
