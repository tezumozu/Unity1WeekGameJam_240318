using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class SoundPlayer : MonoBehaviour{
    [SerializeField]
    SoundManager SoundManager;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    E_SoundType type;

    private S_SoundOptionData option;

    private void Start() {
        option = SoundManager.GetSoundOptionData;

        //オプションが更新されたら数値を更新
        SoundManager.UpdateOptionAsync
        .Subscribe((data) => {
            option = data;
            if(type == E_SoundType.SE){
                audioSource.volume = option.Sound * option.SE;
            }else{
                audioSource.volume = option.Sound * option.BGM;
            }
        })
        .AddTo(this);
    }

    public void PlaySE(AudioClip se){
        //音量を
        audioSource.volume = option.Sound * option.SE;
        audioSource.PlayOneShot(se);
    }

    public void PlayBGM(AudioClip bgm){
        StopSound();
        //音量を
        audioSource.volume = option.Sound * option.BGM;
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayBGM(AudioClip bgm , bool isLoop){
        StopSound();
        //音量を
        audioSource.volume = option.Sound * option.BGM;
        audioSource.clip = bgm;
        audioSource.loop = isLoop;
        audioSource.Play();
    }

    public void StopSound(){
        audioSource.Stop();
    }

    public IEnumerator WaitFinishSEPlay(AudioClip sound){
        PlaySE(sound);

        while(audioSource.isPlaying){
            yield return null;
        }
    }

}
