using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusUIManager : MonoBehaviour{
    public abstract void SetStatus(S_BattleActorStatus status);

    public abstract void SetActiveBeforeStatusEffect(E_BeforeStatusEffect type,bool flag);
    public abstract void SetActiveBeforeStatusEffect(bool flag);

    public abstract void SetActiveAfterStatusEffect(E_AfterStatusEffect type,bool flag);
    public abstract void SetActiveAfterStatusEffect(bool flag);

    public abstract void UpdateBuff(List<E_Buff> buffList);
}
