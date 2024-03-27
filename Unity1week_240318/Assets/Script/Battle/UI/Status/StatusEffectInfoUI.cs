using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StatusEffectInfoUI : MonoBehaviour{
    [SerializeField]
    Image Icon;

    [SerializeField]
    Sprite defo;

    [SerializeField]
    Text NameText;

    [SerializeField]
    Text EffectText;

    public void SetInfo(Sprite newSprite, string EffectName, string EffectText){
        Icon.sprite = newSprite;
        NameText.text = EffectName;
        this.EffectText.text = EffectText;
    }

    public void SetActive(bool flag){
        if(!flag){
            //デストロイ対策
            Icon.sprite = defo;
        }

        gameObject.SetActive(flag);
    }
}
