using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using Zenject;

namespace My1WeekGameSystems_ver2{
    public class GameLoopManager : MonoBehaviour{
        
        bool isHaveToLoading;

        E_SceneName nextScene;

        E_LoopState currentState;

        private SceneLoader sceneLoader;
        private IDisposable sceneLoad_idisposable;
        
        [SerializeField] 
        private GameObject loadingUIObject;

        [Inject]
        private I_SceneObjectUpdatable sceneObjectUpdataer;


        //初期化処理
        void Start(){
            //パラメータ初期化
            isHaveToLoading = false;
            currentState = E_LoopState.Init;
            sceneLoader = new SceneLoader(loadingUIObject);
            loadingUIObject.SetActive(false);
        }


        //各フレームごとの処理
    void Update(){
        switch(currentState){

            //ゲームを開始する
            case E_LoopState.Init :
            
                //シーン内のオブジェクト取得・生成・初期化
                I_SceneLoadAlertable gameManager = sceneObjectUpdataer.InitObject();
                
                //シーンの切り替えタイミングを監視
                sceneLoad_idisposable = gameManager.ObserveSceneLoadAlert(activeIsHaveToLoading);

                currentState = E_LoopState.Update;
                sceneObjectUpdataer.StartGame();

                break;



            //Update処理
            case E_LoopState.Update :
                //オブジェクトをUpdate
                sceneObjectUpdataer.UpdateObject();

                //シーンロードが必要ならば
                if(isHaveToLoading){
                    
                    currentState = E_LoopState.Loading;

                    //購読終了
                    sceneLoad_idisposable.Dispose();

                    //読み込みを開始する(コルーチン)
                    StartCoroutine(sceneLoader.LoadScene(nextScene));

                    //読み込みを開始したのでフラグをfalseに
                    isHaveToLoading = false;

                    //終了時処理
                    sceneObjectUpdataer.ReleaseObject();
                }

                break;



            //Loading時（シーン切り替え時）の処理
            case E_LoopState.Loading :
                //基本待機　何かあれば
                break;
        }
    }


        //シーン切り替え時の処理
        private void activeIsHaveToLoading(E_SceneName sceneName){
            isHaveToLoading = true;
            nextScene = sceneName;
        }


        private enum E_LoopState {
            Init,
            Update,
            Loading
        }
    }
}
