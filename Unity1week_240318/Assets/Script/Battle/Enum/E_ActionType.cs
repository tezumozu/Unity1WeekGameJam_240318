using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ActionType {
    Attack,
    Defense,
    
    Cure_I,
    CureStatus,
    ClearBuff,
    Cure_II,
    ResetBuff,
    CriticalBuff,
    MPAccel,
    CureAll,

    AttackBuff,
    HiAttack_I,
    DefenseDebuff,
    TrueAttack,
    FullSwing_I,
    HiAttack_II,
    GrowUP,
    CrushAttack,
    FullSwing_II,

    PowerDefense,
    DefenseBuff,
    AttackDeBuff,
    CureAttack_I,
    DefenseAndDefenseBuff,
    AttackDefense,
    CureAttack_II,
    SwordCrush,
    AllGuard,

    Poison,
    Venom,
    PoisonSoak,
    PoisonHi_I,
    VenomHI_I,
    VenomHI_II,
    PoisonHi_II,
    VenomHI_III,
    Revenge,

    Flame_I,
    Ice_I,
    Thunder_I,
    FlameBuff,
    IceBuff,
    ThunderBuff,
    FlameDefenseDebuff,
    IceDefenseDebuff,
    ThunderDefenseDebuff,
    Flame_II,
    Ice_II,
    Thunder_II,
    MagicBuff_II,
    Cometto,
    Chaos,
    AllMagicBuff,
    Meteo,

    FlameDefenseBuff,
    IceDefenseBuff,
    ThunderDefenseBuff,
    FlameDebuff,
    IceDebuff,
    ThunderDebuff,
    DefenseAndFlameBuff,
    DefenseAndIceBuff,
    DefenseAndThunderBuff,
    MPDrain_I,
    AntiFlame,
    AntiIce,
    AntiThunder,
    DefenseAndAllElementDefenseUP,
    MPDrain_II,
    MagicDefense,
    HPAndMPDrain,

    Paralysis_I,
    SleepAttack_I,
    Paralysis_II,
    SleepAttack_II,
    ParalysisAttack,
    Sleep,
    DefenseAndParalysisAttackDebuff,
    AtackAndSleepAttackBuff,
    DefenseAndParalysisCure,
    AtackAndSleepTrueAttack,
    DefenseAndParalysisResetStaus,
    AtackAndSleepResetStaus,
    DefenseAndParalysisDefenseBuff,
    AtackAndSleepMagicBuff,
    StatusEffectHIAttack,

    //Rare
    Regene,

    MagicBuff_I,

    AllBuff,
    CriticalTrueAttack,
    StatusGuard,

    SelfDestruction,
    RecoilBuff,

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
    ArmCrush,

    Slash,
    Bomb,
    Bless,
    DragonsWakeUp,
    DragonsAnger,
    ImperialWrath,
    BlackMeteo,

    //  状態異常系
    Wait,
    ParalysisEffect,
    SleepEffect,
    SilenceEffect,
    ArmCrush_NEXT,

    // 追加
    FlameWear,
    GuardStyle
}
