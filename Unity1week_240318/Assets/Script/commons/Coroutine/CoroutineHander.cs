using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class CoroutineHander : MonoSingleton<CoroutineHander>{

    static Dictionary<IEnumerator,Coroutine> ActiveCoroutinDic = new Dictionary<IEnumerator,Coroutine>();
    static Subject<IEnumerator> FinishCoroutinSubject;


    void Start(){
        if(FinishCoroutinSubject is null){
            FinishCoroutinSubject = new Subject<IEnumerator>();

            FinishCoroutinSubject.Subscribe((coroutine)=>{
                //終了したコルーチンをリストから削除する
                ActiveCoroutinDic.Remove(coroutine);
            })
            .AddTo(this);
        }
    }


    public static Coroutine OrderStartCoroutine(IEnumerator coroutine){
        var result = instance.StartCoroutine(CheckFinishCoroutine(coroutine));
        return result;
    }


    public static void StopAllActiveCoroutine(){
        foreach(var coroutine in ActiveCoroutinDic.Values){
            instance.StopCoroutine(coroutine);
        }

        //メモリがたまらないか不安
        ActiveCoroutinDic.Clear();
    }


    public static void OrderStopCoroutine(IEnumerator target){
        instance.StopCoroutine(ActiveCoroutinDic[target]);
    }


    private static IEnumerator CheckFinishCoroutine(IEnumerator coroutine){
        var activeCoroutine = instance.StartCoroutine(coroutine);

        ActiveCoroutinDic[coroutine] = activeCoroutine;

        //コルーチンの終了を待つ
        yield return activeCoroutine;

        //終了したコルーチンを通知する
        FinishCoroutinSubject.OnNext(coroutine);
    }
}
