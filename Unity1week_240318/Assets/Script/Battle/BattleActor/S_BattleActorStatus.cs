
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct S_BattleActorStatus{
    [SerializeField]
    public string Name;
    [SerializeField]
    public int Level;
    [SerializeField]
    public E_MonsterImage Image;
    [SerializeField]
    public int HP;
    [SerializeField]
    public int MP;
    [SerializeField]
    public int Attack;
    [SerializeField]
    public int Defense;
    [SerializeField]
    public int Speed;
    [SerializeField]
    public float CriticalCorrection;

    //属性耐性
    [SerializeField]
    private float NomalDamageResistanceRate;
    [SerializeField]
    private float FlameResistanceRate;
    [SerializeField]
    private float IceResistanceRate;
    [SerializeField]
    private float ThunderResistanceRate;


    //状態異常A耐性
    [SerializeField]
    private bool ParalysisResistance;
    [SerializeField]
    private bool SilenceResistance;
    [SerializeField]
    private bool SleepResistance;

    //状態異常B耐性
    [SerializeField]
    private bool PoisonResistance;
    [SerializeField]
    private bool VenomResistance;
    [SerializeField]
    private bool TimeBombResistance;


    private Dictionary<E_Element,float> elementResistanceRateDic;
    private Dictionary<E_BeforeStatusEffect,bool> beforeStatusEffectResistanceDic;
    private Dictionary<E_AfterStatusEffect,bool> afterStatusEffectResistanceDic;

    //ゲッター
    public Dictionary<E_Element,float> ElementResistanceRateDic{
        get{
            if(elementResistanceRateDic is null){
                elementResistanceRateDic = new Dictionary<E_Element,float>();
                elementResistanceRateDic[E_Element.Non] = NomalDamageResistanceRate;
                elementResistanceRateDic[E_Element.Flame] = FlameResistanceRate;
                elementResistanceRateDic[E_Element.Ice] = IceResistanceRate;
                elementResistanceRateDic[E_Element.Thunder] = ThunderResistanceRate;
                elementResistanceRateDic[E_Element.TrueDamage] = 0.0f;
                elementResistanceRateDic[E_Element.Weakness] = 0.5f;
            }

            return new Dictionary<E_Element,float>(elementResistanceRateDic);
        }
    }


    public Dictionary<E_BeforeStatusEffect,bool> BeforeStatusEffectResistanceDic{
        get{
            if(beforeStatusEffectResistanceDic is null){
                beforeStatusEffectResistanceDic = new Dictionary<E_BeforeStatusEffect,bool>();
                beforeStatusEffectResistanceDic[E_BeforeStatusEffect.Paralysis] = ParalysisResistance;
                beforeStatusEffectResistanceDic[E_BeforeStatusEffect.Silence] = SilenceResistance;
                beforeStatusEffectResistanceDic[E_BeforeStatusEffect.Sleep] = SleepResistance;
            }
            
            return new Dictionary<E_BeforeStatusEffect,bool> (beforeStatusEffectResistanceDic);
        }
    }


    private Dictionary<E_AfterStatusEffect,bool> AfterStatusEffectResistanceDic{
        get{
            if(afterStatusEffectResistanceDic is null){
                afterStatusEffectResistanceDic = new Dictionary<E_AfterStatusEffect,bool>();
                afterStatusEffectResistanceDic[E_AfterStatusEffect.Poison] = PoisonResistance;
                afterStatusEffectResistanceDic[E_AfterStatusEffect.Venom] = VenomResistance;
                afterStatusEffectResistanceDic[E_AfterStatusEffect.TimeBomb] = TimeBombResistance;
            }
            
            
            return new Dictionary<E_AfterStatusEffect,bool> (afterStatusEffectResistanceDic);
        }
    }

} 
