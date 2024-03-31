using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorImage : MonoBehaviour{
    [SerializeField]
    ActorAnimManager manager;

    public void FinishAnim(){
        Debug.Log("test");
        manager.FinishAnim();
    }
}
