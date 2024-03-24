using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_DamageApplicable{
    //ダメージを受ける
    public abstract int DamageAppliy(int damagePoint,E_Element elementType);

    //バフ・デバフを受ける
    public abstract List<string> BuffAppliy(E_Buff buffType,int turn);

    //状態異常Aを受ける
    public abstract List<string> BuffAppliy(E_BeforeStatusEffect effectType);

    //状態異常Bを受ける
    public abstract List<string> BuffAppliy(E_AfterStatusEffect effectType);
}
