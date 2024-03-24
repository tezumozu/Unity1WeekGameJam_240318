using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_BuffCreatable {
    public abstract BattleBuff CreateBuff(E_Buff type,int turn);
}
