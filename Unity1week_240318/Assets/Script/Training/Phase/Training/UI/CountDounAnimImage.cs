using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDounAnimImage : MonoBehaviour{
    [SerializeField]
    CountDownUIManager manager;

    public void FinishAnim(){
        manager.FinishAnim();
    }

    public void PlaySE(){
        manager.PlaySE();
    }
}
