using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_DamageApplicable{
    //ダメージを受ける
    public abstract IEnumerator AppliyDamage(int damagePoint,E_Element elementType);

    //バフ・デバフを受ける
    public abstract IEnumerator AppliyBuff(E_Buff buffType,int turn);
    public abstract IEnumerator AppliyBuff(Dictionary<E_Buff,int> buffList);
    public abstract IEnumerator AppliyDeBuff(E_Buff buffType,int turn);
    public abstract IEnumerator AppliyDeBuff(Dictionary<E_Buff,int> buffList);

    //状態異常Aを受ける
    public abstract IEnumerator AppliyEffect(E_BeforeStatusEffect effectType);

    //状態異常Bを受ける
    public abstract IEnumerator AppliyEffect(E_AfterStatusEffect effectType);

    //回復を受ける
    public abstract IEnumerator AppliyHeel(int heelPoint);
    public abstract IEnumerator AppliyMPHeel(int heelPoint);

    //バフを消す
    public abstract IEnumerator ClearBuff();
    public abstract IEnumerator ClearBuff(E_BuffType type);
    public abstract IEnumerator ClearBuff(E_Buff type);
    public abstract IEnumerator ClearBuff(List<E_Buff> list , E_BuffType animType);

    //状態異常を消す
    public abstract IEnumerator ClearEffect(E_BuffType type);
}
