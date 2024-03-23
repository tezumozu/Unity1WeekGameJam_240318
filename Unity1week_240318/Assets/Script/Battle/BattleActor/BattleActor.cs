using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class BattleActor : I_DamageApplicable{

    //Subjects
    private Subject<Unit> isDeadSubject;
    public IObservable<Unit> isDeadAsync => isDeadSubject;

    protected S_BattleActorStatus maxStatus;
    protected S_BattleActorStatus currentStatus;
    protected E_BeforeStatusEffect currentBeforeStatusEffect;
    protected E_AfterStatusEffect currentAfterStatusEffect;
    protected List<E_ActionType> skillList;
    protected Dictionary<E_Buff,int> buffDic;


    public S_BattleActorStatus GetMaxStatus{
        get{ return maxStatus; }
    }

    public S_BattleActorStatus GetCurrentStatus{
        get{ return currentStatus; }
    }

    public E_BeforeStatusEffect GetCurrentBeforeStatusEffect{
        get{ return currentBeforeStatusEffect; }
    }

    public E_BeforeStatusEffect GetCurrentAftoreStatusEffect{
        get{ return currentBeforeStatusEffect; }
    }

    public List<E_ActionType> GetSkillList{
        get{ return new List<E_ActionType>(skillList); }
    }

    public Dictionary<E_Buff,int> GetBuffDic{
        get{ return new Dictionary<E_Buff,int>(buffDic); }
    }


    public BattleActor(){
        isDeadSubject = new Subject<Unit>();
    }

    public abstract List<string> CheckBeforeStatusEffect();
    public abstract List<string> ActionBattleActor(E_ActionType type,I_DamageApplicable enemy);
    public abstract List<string> CheckAfterStatusEffect();
    public abstract List<string> RefreshBattleActor();
}
