using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_DamageApplicable{
    //ダメージを受ける
    public abstract IEnumerator AppliyDamage(int damagePoint,E_Element elementType);

    //バフ・デバフを受ける
    public abstract IEnumerator AppliyBuff(E_Buff buffType,int turn);

    //状態異常Aを受ける
    public abstract IEnumerator AppliyEffect(E_BeforeStatusEffect effectType);

    //状態異常Bを受ける
    public abstract IEnumerator AppliyEffect(E_AfterStatusEffect effectType);

    //回復を受ける
    public abstract IEnumerator AppliyHeel(int heelPoint);

    //バフを消す
    public abstract IEnumerator ClearBuff();

    //状態異常を消す
    public abstract IEnumerator ClearEffect();
}
