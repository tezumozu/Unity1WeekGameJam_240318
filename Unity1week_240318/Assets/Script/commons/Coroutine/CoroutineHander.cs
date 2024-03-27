using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class CoroutineHander : MonoSingleton<CoroutineHander>{

    static List<Coroutine> ActiveCoroutinList = new List<Coroutine>();
    static Subject<Coroutine> FinishCoroutinSubject;


    void Start(){
        if(FinishCoroutinSubject is null){
            FinishCoroutinSubject = new Subject<Coroutine>();


            FinishCoroutinSubject.Subscribe((coroutine)=>{
                //終了したコルーチンをリストから削除する
                ActiveCoroutinList.Remove(coroutine);
            })
            .AddTo(this);
        }
    }


    public static void OrderStartCoroutine(IEnumerator coroutine){
        instance.StartCoroutine(CheckFinishCoroutine(coroutine));
    }


    public static void StopAllCoroutine(){
        foreach(var coroutine in ActiveCoroutinList){
            instance.StopCoroutine(coroutine);
        }
    }


    static IEnumerator CheckFinishCoroutine(IEnumerator coroutine){
        var activeCoroutine = instance.StartCoroutine(coroutine);

        ActiveCoroutinList.Add(activeCoroutine);

        //コルーチンの終了を待つ
        yield return activeCoroutine;

        //終了したコルーチンを通知する
        FinishCoroutinSubject.OnNext(activeCoroutine);
    }
}
