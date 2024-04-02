using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ActionType {
    Attack,
    Defense,
    
    Cure1,
    CureStatus,
    GainBuff,
    Cure2,
    ReSetBuff,
    CriticalBuff,
    CureAll,
    Cure2_and_CureStatus,

    HiAttack1,
    AttackBuff,
    DefenseDebuff,
    TrueAttack,
    FullSwing1,
    HiAttack2,
    GrowAttack,
    CrushAttack,
    FullSwing2,

    PowerDefense,
    DefenseBuff,
    AttackDeBuff,
    CureAttack1,
    DefenseAndDefenseBuff,
    AttackDefense,
    CureAttack2,
    AllGuard,
    Robust,

    Poison,
    Venom,
    PoisonSoak,
    PoisonAttackUP,
    PoisonDefenseUP,
    HiPoisonAttackAndBuff,
    HiPoisonAttackAndDebuff,
    HiPoisonAttackAndCure,
    PoisonTrueAttackAndCritical,

    Flame1,
    Ice1,
    Thunder1,
    FlameBuff,
    IceBuff,
    ThunderBuff,
    FlameDebuff,
    IceDebuff,
    ThunderDebuff,
    Flame2,
    Ice2,
    Thunder2,
    MPAccel,
    MagicBuff,
    Chaos,
    AllMagicBuff,
    Meteo,

    FlameDefenseBuff,
    IceDefenseBuff,
    ThunderDefenseBuff,
    FlameDefenseDebuff,
    IceDefenseDebuff,
    ThunderDefenseDebuff,
    DefenseAndFrameDefenseBuff,
    DefenseAndIceDefenseBuff,
    DefenseAndThunderDefenseBuff,
    MPDrain1,
    DefenseAndAllElemntBuff,
    DefenseAndAllElemntDefenseBuff,
    MPDrain2,
    DefenseAndMagicBuff,
    HPAndMPDrain,

    Paralysis1,
    SleepAttack1,
    Paralysis2,
    SleepAttack2,
    ParalysisAttack,
    Sleep,
    DefenseAndParalysisAttackDebuff,
    AtackAndSleepTrueAttack,
    DefenseAndParalysisCure,
    AtackAndSleepAttackBuff,
    DefenseAndParalysisNormalAttackDeBuff,
    AtackAndSleepNormalAttackBuff,
    DefenseBuffAndParalysisAttackDebuff,
    AtackBuffAndDefenseDebuff,
    StatusEffectHIAttack,

    //Rare
    Rejene,
    CriticalAttack,

    Cometto,

    AllBuff,
    CriticalTrueAttack,
    StatusGuard,

    Muscle,
    Lariat,

    SelfDestruction,

    //Enemy
    PoisonSlimy,
    BecomeHard,
    Forward,
    Anger,

    FlameSlash,
    BoneCurse,

    VenomBite,
    SleepBite,
    ShutUp,
    SilenceCurse,
    SilenceBite,

    Ironclad,
    ClearBuff,
    ArmCrush,

    Slash,
    Bomb,
    DragonsWakeUp,
    DragonsAnger,
    ImperialWrath,
    DragonsGuard,

    //  状態異常系
    ParalysisEffect,
    SleepEffect,
    SilenceEffect
}
