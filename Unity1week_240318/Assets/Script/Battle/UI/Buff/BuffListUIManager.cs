using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffListUIManager : MonoBehaviour{

    [SerializeField]
    GameObject IconPrefub;

    [SerializeField]
    private BuffInfoUIManager infoUIManager;

    public void SetList(IEnumerable<BattleBuff> buffList , bool directionFlag){
        float direction = -1.0f;
        if(directionFlag) direction = 1.0f;

        //子を殺す
        //現在のContent内のオブジェクトを削除
        var transform = gameObject.transform;
        foreach(Transform Icon in transform){
            Destroy(Icon.gameObject);
        }


        //生成

        int count = 0;
        int columnCount = 0;

        foreach (var buff in buffList){

            //座標計算
            float x = 37.5f * direction - 37.5f * direction * (float)columnCount;
            float y = 62.5f - 37.5f * count;

            //プレハブを生成
            //インスタンス化
            var IconObject = Instantiate(IconPrefub);

            // プレハブを指定位置に設置
            var rect_transform = IconObject.GetComponent<RectTransform>();
            rect_transform.position = new Vector2( x , y );

            //Iconを初期化
            var buffIcon = IconObject.GetComponent<BuffIconUI>();
            buffIcon.InitIcon( buff.BuffData , buff.TurnCount , infoUIManager );

            //Contensへ格納
            IconObject.transform.SetParent(gameObject.transform,false);

            count++;
            count = count % 3;
            if(count == 0){
                columnCount++;
            }
        }
    }
}
