using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeforeStatusEffect{
    public string EffectName { get; protected set; }
    public E_BeforeStatusEffect Type { get; protected set; }
    public string EffectText{ get; protected set; }
    public BattleActorAction EffectAction { get; protected set; }
    public string RecoveryText{ get; protected set; }

    protected I_ActionCreatable actionFactory;

    protected BeforeStatusEffect(I_ActionCreatable actionFactory){
        this.actionFactory = actionFactory;
    }

    public abstract bool AppliyEffect(BattleActor actor);
    public abstract bool CheckContinueEffect();
}
