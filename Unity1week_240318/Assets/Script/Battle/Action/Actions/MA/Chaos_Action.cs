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
                    buffList[(E_Buff)type] = 2;
                }
            }
        }

        if(buffList.Count > 0){
            yield return diffender.AppliyDeBuff( buffList );
        }


        //ランダムに状態異常
        var beforeEffectList = new List<E_BeforeStatusEffect>();
        beforeEffectList.Add(E_BeforeStatusEffect.Paralysis);
        beforeEffectList.Add(E_BeforeStatusEffect.Sleep);
        beforeEffectList.Add(E_BeforeStatusEffect.Silence);

        int rand = UnityEngine.Random.Range(0,beforeEffectList.Count);

        if(UnityEngine.Random.Range(0.0f,1.0f) < 0.5){
            yield return diffender.AppliyEffect( beforeEffectList[rand] );
        }


        //ハードすぎる
        var AfterEffectList = new List<E_AfterStatusEffect>();
        AfterEffectList.Add(E_AfterStatusEffect.Poison);
        AfterEffectList.Add(E_AfterStatusEffect.Venom);
        AfterEffectList.Add(E_AfterStatusEffect.TimeBomb);

        rand = UnityEngine.Random.Range(0,AfterEffectList.Count);

        if(UnityEngine.Random.Range(0.0f,1.0f) < 0.5){
            yield return diffender.AppliyEffect( AfterEffectList[rand] );
        }

    }
}
