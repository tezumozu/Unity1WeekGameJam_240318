using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvoAnimManager : MonoBehaviour{

    [SerializeField]
    Animator animator;

    [SerializeField]
    SoundPlayer soundPlayer;

    private bool isFinishAnim = false;

    public IEnumerator StartAnim(){
        isFinishAnim = false;

        animator.SetTrigger("EvoAnim");

        while(!isFinishAnim){
            yield return false;
        }

        yield return true;
    }

    public void FinishAnim(){
        isFinishAnim = true;
    }

    public void PlaySE(AudioClip se){
        soundPlayer.PlaySE(se);
    }


}
