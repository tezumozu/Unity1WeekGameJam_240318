using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_StatusEffectCreatable {
    public abstract AfterStatusEffect CreateEffect(E_AfterStatusEffect type);
    public abstract BeforeStatusEffect CreateEffect(E_BeforeStatusEffect type);
}
