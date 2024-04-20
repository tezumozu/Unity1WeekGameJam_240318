using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : I_EnemyCreatable{

    private delegate BattleActor GetEnemy();

    private Dictionary<E_EnemyType,GetEnemy> EnemyDic;

    public EnemyFactory(){
        EnemyDic = new Dictionary<E_EnemyType,GetEnemy>();
        EnemyDic[E_EnemyType.TestEnemy] =   () => {return new EnemyBattleActor( new ActionFactory() , new BuffFactory() , new StatusEffectFactory() );};
        EnemyDic[E_EnemyType.Slime] =       () => {return new SlimeActor( new ActionFactory() , new BuffFactory() , new StatusEffectFactory() );};
        EnemyDic[E_EnemyType.Skeleton] =    () => {return new SkeletonActor( new ActionFactory() , new BuffFactory() , new StatusEffectFactory() );};
        EnemyDic[E_EnemyType.Mimic] =       () => {return new MimicActor( new ActionFactory() , new BuffFactory() , new StatusEffectFactory() );};
        EnemyDic[E_EnemyType.Golem] =       () => {return new GolemActor( new ActionFactory() , new BuffFactory() , new StatusEffectFactory() );};
        EnemyDic[E_EnemyType.Dragon] =      () => {return new DragonActor( new ActionFactory() , new BuffFactory() , new StatusEffectFactory() );};
    }

    public BattleActor CreateEnemy(E_EnemyType type){
        return EnemyDic[type]();
    }
}

public interface  I_EnemyCreatable{
    public abstract BattleActor CreateEnemy(E_EnemyType type);   
}
