using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class BattleActor{

    //Subjects
    private Subject<Unit> isDeadSubject;
    public IObservable<Unit> isDeadAsync => isDeadSubject;

    public S_BattleActorStatus maxStatus;
    private S_BattleActorStatus currentStatus;

    public S_BattleActorStatus GetMaxStatus{
        get{
            return maxStatus;
        }
    }

    public S_BattleActorStatus GetCurrentStatus{
        get{
            return currentStatus;
        }
    }

    public BattleActor(S_BattleActorStatus status){
        maxStatus = status;
        currentStatus = status;
        isDeadSubject = new Subject<Unit>();
    }

    public void test(){
        isDeadSubject.OnNext(Unit.Default);
    }
}
