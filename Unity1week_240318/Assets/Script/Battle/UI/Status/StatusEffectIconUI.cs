using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

using UnityEngine.UI;

public class StatusEffectIconUI : MonoBehaviour{
    [SerializeField]
    Image Icon;

    [SerializeField]
    StatusEffectInfoUI statusEffectInfoUI;

    private Subject<E_BeforeStatusEffect> BeforeEffectUpdateSubject = new Subject<E_BeforeStatusEffect>();
    public IObservable<E_BeforeStatusEffect> BeforeEffectUpdateAsync => BeforeEffectUpdateSubject; 

    string EffectName = "テスト";
    string EffectText = "テスト";

    public void SetData(E_BeforeStatusEffect effectType, string EffectName, string EffectText){
        BeforeEffectUpdateSubject.OnNext(effectType);

        if(effectType == E_BeforeStatusEffect.Non){
            gameObject.SetActive(false);
            return;
        }

        //Spriteの取得
        //パスを生成
        var fileName = "BattleScene/Effect/Image/Before/" + ((int)effectType).ToString();
        //読み込む
        var newSprite = Resources.Load<Sprite>(fileName);
        if(newSprite == null){
            Debug.Log("noImage");
        }

        Icon.sprite = newSprite;
        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

        this.EffectName = EffectName;
        this.EffectText = EffectText;

        gameObject.SetActive(true);
    }

    public void SetData(E_AfterStatusEffect effectType, string EffectName, string EffectText){
        if(effectType == E_AfterStatusEffect.Non){
            gameObject.SetActive(false);
            return;
        }

        //Spriteの取得
        //パスを生成
        var fileName = "BattleScene/Effect/Image/After/" + ((int)effectType).ToString();
        //読み込む
        var newSprite = Resources.Load<Sprite>(fileName);
        if(newSprite == null){
            Debug.Log("noImage");
        }

        Icon.sprite = newSprite;
        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();

        this.EffectName = EffectName;
        this.EffectText = EffectText;

        gameObject.SetActive(true);
    }

    //
    public void OnMouseOver() {
        statusEffectInfoUI.SetInfo(Icon.sprite , EffectName , EffectText);
        statusEffectInfoUI.SetActive(true);
    }

    //
    public void OnMouseExit() {
        statusEffectInfoUI.SetActive(false);
    }
}
