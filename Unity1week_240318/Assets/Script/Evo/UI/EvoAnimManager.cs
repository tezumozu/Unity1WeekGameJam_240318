using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvoAnimManager : MonoBehaviour{

    [SerializeField]
    Animator animator;

    [SerializeField]
    SoundPlayer soundPlayer;

    [SerializeField]
    Image EvoImage;

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

    public void SetEvoImage(E_MonsterImage imageType){

         //スプライト読み込み
        var newSprite = Resources.Load<Sprite>( "BattleScene/ActorImage/" + ((int)imageType).ToString() );
        if(newSprite is null) Debug.Log("No Image!");
        
        EvoImage.sprite = newSprite;

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();
    }


}
