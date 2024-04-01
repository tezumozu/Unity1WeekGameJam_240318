using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorImage : MonoBehaviour{
    [SerializeField]
    ActorAnimManager manager;

    [SerializeField]
    AudioClip AttackSE;

    [SerializeField]
    AudioClip DamagedSE;

    [SerializeField]
    AudioClip DeadSE;

    [SerializeField]
    SoundPlayer player;

    public void FinishAnim(){
        manager.FinishAnim();
    }

    public void PlayDamagedSE(){
        player.PlaySE(DamagedSE);
    }

    public void PlayAttackedSE(){
        player.PlaySE(AttackSE);
    }

    public void PlayDeadSE(){
        player.PlaySE(DeadSE);
    }
}
