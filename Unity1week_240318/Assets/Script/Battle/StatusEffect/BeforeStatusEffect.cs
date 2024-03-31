using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeforeStatusEffect{

    public readonly BeforeStatusEffectData EffectData;

    protected I_ActionCreatable actionFactory;

    protected BeforeStatusEffect(E_BeforeStatusEffect effectType,I_ActionCreatable actionFactory){
        this.actionFactory = actionFactory;

        //パスを生成
        var fileName = "BattleScene/Effect/BeforeStatusEffectList";
        //読み込む
        var dataList = Resources.Load<BeforeStatusEffectDataList>(fileName);
        foreach(var data in dataList.DataList){
            if (data.EffectType == effectType){
                EffectData = data;
            }
        }

        Resources.UnloadUnusedAssets();
    }

    public abstract BattleActorAction AppliyEffect(BattleActorAction action);
    public abstract bool CheckContinueEffect();
}
