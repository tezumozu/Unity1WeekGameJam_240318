using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActorUIManager : MonoBehaviour{

    protected Slider HPSlider;
    protected Text HPSliderNum;

    [SerializeField]
    protected GameObject BuffList;

    [SerializeField]
    protected GameObject StatusBer;

    [SerializeField]
    protected GameObject StatusEffects;

    [SerializeField]
    protected Image ActorImage;

    [SerializeField]
    protected StatusEffectIconUI beforeStatusEffectIcon;

    [SerializeField]
    protected StatusEffectIconUI afterStatusEffectIcon;

    [SerializeField]
    protected BuffListUIManager buffListUIManager;


    public abstract void SetStatus(S_BattleActorStatus currentState , S_BattleActorStatus maxStatus);

    public virtual void SetBeforeStatusEffect(BeforeStatusEffectData data){
        beforeStatusEffectIcon.SetData(data.EffectType , data.EffectName , data.EffectText);
    }

    public virtual void SetAfterStatusEffect(AfterStatusEffectData data){
        afterStatusEffectIcon.SetData(data.EffectType , data.EffectName , data.EffectText);
    }

    public abstract void SetBuffList(IEnumerable<BattleBuff> buffList);
}
