using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActorUIManager : MonoBehaviour{
    [SerializeField]
    protected GameObject BuffList;

    [SerializeField]
    protected GameObject StatusBer;

    [SerializeField]
    protected GameObject StatusEffects;

    [SerializeField]
    protected Image ActorImage;


    public abstract void SetStatus(S_BattleActorStatus currentState , S_BattleActorStatus maxStatus);

    public abstract void SetActiveBeforeStatusEffect(E_BeforeStatusEffect type,bool flag);

    public abstract void SetActiveAfterStatusEffect(E_AfterStatusEffect type,bool flag);

    public abstract void UpdateBuff(List<E_Buff> buffList);

    public abstract IEnumerator StartActorAnim(E_ActorAnim anim);
}
