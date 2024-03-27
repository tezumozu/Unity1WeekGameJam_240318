using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AfterStatusEffect {
    public AfterStatusEffectData EffectData;

    public AfterStatusEffect (E_AfterStatusEffect effectType){
        //パスを生成
        var fileName = "BattleScene/Effect/AfterStatusEffectList";
        //読み込む
        var dataList = Resources.Load<AfterStatusEffectDataList>(fileName);
        foreach(var data in dataList.DataList){
            if (data.EffectType == effectType){
                EffectData = data;
            }
        }

        Resources.UnloadUnusedAssets();
    }

    public abstract IEnumerator AppliyEffect(BattleActor actor);
    public abstract bool CheckContinueEffect();
}
