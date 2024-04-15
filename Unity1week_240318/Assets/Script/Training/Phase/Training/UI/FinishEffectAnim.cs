using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEffectAnim : MonoBehaviour{
    [SerializeField]
    FinishAnimUIManager manager;

    public void FinishAnim(){
        manager.FinishAnim();
    }

    public void PlaySE(){
        manager.PlaySE();
    }
}
