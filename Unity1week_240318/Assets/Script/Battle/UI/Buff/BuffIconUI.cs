using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffIconUI : MonoBehaviour{

    [SerializeField]
    Image IconImage;

    private BuffData data;
    private string turnCount;
    private BuffInfoUIManager infoUI;


    public void InitIcon(BuffData data , int turnCount , BuffInfoUIManager infoUI){
        this.data = data;
        this.turnCount = turnCount.ToString();
        this.infoUI = infoUI;

        //アイコン画像取得

        //パスを生成
        var fileName = "BattleScene/Buff/Image/" + ((int)data.BuffType).ToString();
        //読み込む
        var newSprite = Resources.Load<Sprite>(fileName);
        if(newSprite == null){
            Debug.Log("noImage");
        }

        IconImage.sprite = newSprite;

        //不要なアセットをアンロード
        Resources.UnloadUnusedAssets();
    }

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    public void OnPointerEnter( ){
        infoUI.SetInfo(data,turnCount,IconImage.sprite);
        infoUI.SetActive(true);
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    // 
    public void OnPointerExit( ){
        infoUI.SetActive(false);
    }
}
