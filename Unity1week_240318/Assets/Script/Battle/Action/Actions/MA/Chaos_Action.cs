using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaos_Action : BattleActorAction{

    public Chaos_Action():base(E_ActionType.Chaos){
    }

    public override IEnumerator UseAction(S_BattleActorStatus effectedStatus,BattleActor attacker,BattleActor diffender){

        yield return base.UseAction(effectedStatus,attacker,diffender);

        //ランダムにデバフを付与
        Array array = Enum.GetValues(typeof(E_Buff));
        var buffFactory = new BuffFactory();
        var buffList = new Dictionary<E_Buff,int>();

        //無駄多い
        foreach (var type in array){
            var buff = buffFactory.CreateBuff((E_Buff)type,3);
            if(buff.BuffData.Type == E_BuffType.Debuff){
                if(UnityEngine.Random.Range(0.0f,1.0f) < 0.5){
                    buffList[(E_Buff)type] = 3;
                }
            }
        }

        if(buffList.Count > 0){
            yield return diffender.AppliyDeBuff( buffList );
        }


        //ランダムに状態異常
        array = Enum.GetValues(typeof(E_BeforeStatusEffect));
        var statusEffectFactory = new StatusEffectFactory();

        //無駄多い
        foreach (var type in array){
            var statusEffect = statusEffectFactory.CreateEffect((E_BeforeStatusEffect)type);
            if(statusEffect.EffectData.Type == E_BuffType.Debuff){
                if(UnityEngine.Random.Range(0.0f,1.0f) < 0.5){
                    yield return diffender.AppliyEffect( (E_BeforeStatusEffect)type );
                    break;
                }
            }
        }


        array = Enum.GetValues(typeof(E_AfterStatusEffect));

        //無駄多い
        foreach (var type in array){
            var statusEffect = statusEffectFactory.CreateEffect((E_BeforeStatusEffect)type);
            if(statusEffect.EffectData.Type == E_BuffType.Debuff){
                if(UnityEngine.Random.Range(0.0f,1.0f) < 0.5){
                    yield return diffender.AppliyEffect( (E_BeforeStatusEffect)type );
                    break;
                }
            }
        }

    }
}
