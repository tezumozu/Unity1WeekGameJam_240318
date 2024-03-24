using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHander : MonoSingleton<CoroutineHander>{
    public static Coroutine OrderStartCoroutine(IEnumerator coroutine){
        return instance.StartCoroutine(coroutine);
    }
}
