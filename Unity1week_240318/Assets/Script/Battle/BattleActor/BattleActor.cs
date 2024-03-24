using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class BattleActor : I_DamageApplicable{
    protected S_BattleActorStatus maxStatus;
    protected S_BattleActorStatus currentStatus;
    protected BeforeStatusEffect currentBeforeStatusEffect;
    protected AfterStatusEffect currentAfterStatusEffect;
    protected List<E_ActionType> skillList;
    protected Dictionary<E_Buff,BattleBuff> buffDic;
    protected bool isStan;

    protected I_ActionCreatable actionFactotry;
    protected I_StatusEffectCreatable statusEffectFactory;
    protected I_BuffCreatable buffFactory;

    public BattleActorAction CurrentAction {get; protected set;}


    //Subjects
    private Subject<Unit> isDeadSubject;
    public IObservable<Unit> isDeadAsync => isDeadSubject;


    public S_BattleActorStatus GetMaxStatus{
        get{ return maxStatus; }
    }

    public S_BattleActorStatus GetCurrentStatus{
        get{ return currentStatus; }
    }

    public E_BeforeStatusEffect GetCurrentBeforeStatusEffect{
        get{ return currentBeforeStatusEffect.Type; }
    }

    public E_AfterStatusEffect GetCurrentAftoreStatusEffect{
        get{ return currentAfterStatusEffect.Type; }
    }

    public List<E_ActionType> GetSkillList{
        get{ return new List<E_ActionType>(skillList); }
    }

    public Dictionary<E_Buff,BattleBuff> GetBuffDic{
        get{ return new Dictionary<E_Buff,BattleBuff>(buffDic); }
    }


    public BattleActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory){
        actionFactotry = actionFactory;
        isDeadSubject = new Subject<Unit>();
        skillList = new List<E_ActionType>();
        buffDic = new Dictionary<E_Buff,BattleBuff>();

        this.buffFactory = buffFactory;
        this.statusEffectFactory = statusEffectFactory;

        //状態異常をリセット
        currentBeforeStatusEffect = this.statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
        currentAfterStatusEffect = this.statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);
    }

    public abstract List<string> CheckBeforeStatusEffect();
    public abstract List<string> ActionBattleActor(E_ActionType type,I_DamageApplicable enemy);
    public abstract List<string> CheckAfterStatusEffect();
    public abstract List<string> RefreshBattleActor();


    //I_DamageApplicable
    //ダメージを受ける
    public int DamageAppliy(int damagePoint,E_Element elementType){
        int damage = 1;

        return damage;
    }

    //バフ・デバフを受ける
    public List<string> BuffAppliy(E_Buff buffType,int turn){
        var resultTextList = new List<string>();
        return resultTextList;
    }

    //状態異常Aを受ける
    public List<string> BuffAppliy(E_BeforeStatusEffect effectType){
        var resultTextList = new List<string>();
        if(currentBeforeStatusEffect.Type == E_BeforeStatusEffect.EffectProtect){

            var effect = statusEffectFactory.CreateEffect(effectType);
            resultTextList.Add(currentStatus.Name + " は " + effect.EffectName + " を防いだ");

        }else{
            currentBeforeStatusEffect = statusEffectFactory.CreateEffect(effectType);

            resultTextList.Add(currentStatus.Name + " は " + currentBeforeStatusEffect.EffectName + " を受けた！");
        }

        return resultTextList;
    }

    //状態異常Bを受ける
    public List<string> BuffAppliy(E_AfterStatusEffect effectType){
        var resultTextList = new List<string>();

        if(currentAfterStatusEffect.Type == E_AfterStatusEffect.EffectProtect){

            var effect = statusEffectFactory.CreateEffect(effectType);
            resultTextList.Add(currentStatus.Name + " は " + effect.EffectName + " を防いだ");

        }else{
            currentAfterStatusEffect = statusEffectFactory.CreateEffect(effectType);

            resultTextList.Add(currentStatus.Name + " は " + currentAfterStatusEffect.EffectName + " を受けた！");
        }

        return resultTextList;
    }
}
