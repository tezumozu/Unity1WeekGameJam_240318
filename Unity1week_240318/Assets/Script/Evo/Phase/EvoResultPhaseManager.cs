using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;


public class EvoResultPhaseManager : TrainingPhase{

    private EvoResultInputManager inputManager;
    private EvoResultUIManager resultManager;
    private bool isFinish;

    public EvoResultPhaseManager(){
        isFinish = false;
        //UI取得
        inputManager = GameObject.Find("EvoResultInputManager").GetComponent<EvoResultInputManager>();

        var Canvas = GameObject.Find("Canvas");
        resultManager = Canvas.transform.Find("ResultUI").gameObject.GetComponent<EvoResultUIManager>();


        //Resultにデータをセット
        resultManager.SetData();

        var disposable = inputManager.ToNextSceneAsync
        .Subscribe((_)=>{
            isFinish = true;
        });

        DisposeList.Add(disposable);
    }

    public override IEnumerator StartPhase(){

        while(!isFinish){
            yield return null;
        }

        StateFinishSubject.OnNext(Unit.Default);
    }
}
