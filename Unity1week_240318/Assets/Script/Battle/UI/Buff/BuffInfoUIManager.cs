using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffInfoUIManager : MonoBehaviour{
    [SerializeField]
    Image Icon;

    [SerializeField]
    Sprite defo;

    [SerializeField]
    Text NameText;

    [SerializeField]
    Text BuffText;

    [SerializeField]
    Text TurnNum;

    public void SetInfo(BuffData data, string turnCount , Sprite newSprite){
        Icon.sprite = newSprite;
        NameText.text = data.BuffName;
        this.BuffText.text = data.BuffText;

        TurnNum.text = turnCount;
    }

    public void SetActive(bool flag){
        if(!flag){
            //デストロイ対策
            Icon.sprite = defo;
        }

        gameObject.SetActive(flag);
    }
}
