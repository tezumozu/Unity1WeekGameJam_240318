using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AfterStatusEffect {
    public string EffectName { get; protected set; }
    public E_AfterStatusEffect Type { get; protected set; }
    public string EffectText{ get; protected set; }
    public string RecoveryText{ get; protected set; }

    public abstract List<string> AppliyEffect(BattleActor actor);
    public abstract bool CheckContinueEffect();
}
