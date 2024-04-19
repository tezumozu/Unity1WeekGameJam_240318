using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectFactory : I_StatusEffectCreatable{
    public BeforeStatusEffect CreateEffect(E_BeforeStatusEffect type){
        BeforeStatusEffect effect;

        var actionFactory = new ActionFactory();

        switch (type){
            case E_BeforeStatusEffect.Paralysis:
                effect = new ParalysisEffect(actionFactory);
            break;

            case E_BeforeStatusEffect.Sleep:
                effect = new SleepEffect(actionFactory);
            break;

            case E_BeforeStatusEffect.Silence:
                effect = new SilenceEffect(actionFactory);
            break;

            case E_BeforeStatusEffect.MPAccel:
                effect = new MPAccelEffect(actionFactory);
            break;

            case E_BeforeStatusEffect.Non:
                effect = new NonBeforeEffect(actionFactory);
            break;

            case E_BeforeStatusEffect.EffectProtect:
                effect = new BeforeEffectProtect(actionFactory);
            break;

            default:
                effect = new NonBeforeEffect(actionFactory);
            break;
        }

        return effect;
    }



    public AfterStatusEffect CreateEffect(E_AfterStatusEffect type){
        AfterStatusEffect effect;

        switch (type){
            case E_AfterStatusEffect.Poison:
                effect = new PoisonEffect();
            break;

            case E_AfterStatusEffect.Venom:
                effect = new VenomEffect();
            break;

            case E_AfterStatusEffect.TimeBomb:
                effect = new TimeBombEffect();
            break;

            case E_AfterStatusEffect.Regene:
                effect = new AutoCureEffect();
            break;

            case E_AfterStatusEffect.Non:
                effect = new NonAfterEffect();
            break;

            case E_AfterStatusEffect.EffectProtect:
                effect = new AfterEffectProtect();
            break;

            default:
                effect = new NonAfterEffect();
            break;
        }

        return effect;
    }

}
