using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFactory : I_ActionCreatable{

    private delegate BattleActorAction CreateActionClass();

    private Dictionary<E_ActionType,CreateActionClass> ActionDic;

    public ActionFactory(){
        ActionDic = new Dictionary<E_ActionType,CreateActionClass>();

        ActionDic[E_ActionType.Attack] = () => {return new Attack_Action();};
        ActionDic[E_ActionType.Defense] = () => {return new Attack_Action();};


        //HM
        ActionDic[E_ActionType.Cure_I] =        () => {return new Attack_Action();};
        ActionDic[E_ActionType.CureStatus] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.ClearBuff] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.ResetBuff] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.CriticalBuff] =  () => {return new Attack_Action();};
        ActionDic[E_ActionType.MPAccel] =       () => {return new Attack_Action();};
        ActionDic[E_ActionType.Cure_II] =       () => {return new Attack_Action();};
        ActionDic[E_ActionType.CureAll] =       () => {return new Attack_Action();};


        //HA
        ActionDic[E_ActionType.AttackBuff] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.HiAttack_I] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseDebuff] = () => {return new Attack_Action();};
        ActionDic[E_ActionType.TrueAttack] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.FullSwing_I] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.HiAttack_II] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.GrowUP] =        () => {return new Attack_Action();};
        ActionDic[E_ActionType.CrushAttack] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.FullSwing_II] =  () => {return new Attack_Action();};


        //HB
        ActionDic[E_ActionType.PowerDefense] =          () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseBuff] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.AttackDeBuff] =          () => {return new Attack_Action();};
        ActionDic[E_ActionType.CureAttack_I] =          () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndDefenseBuff] = () => {return new Attack_Action();};
        ActionDic[E_ActionType.AttackDefense] =         () => {return new Attack_Action();};
        ActionDic[E_ActionType.CureAttack_II] =         () => {return new Attack_Action();};
        ActionDic[E_ActionType.SwordCrush] =            () => {return new Attack_Action();};
        ActionDic[E_ActionType.AllGuard] =              () => {return new Attack_Action();};


        //HS
        ActionDic[E_ActionType.Poison] =        () => {return new Attack_Action();};
        ActionDic[E_ActionType.Venom] =         () => {return new Attack_Action();};
        ActionDic[E_ActionType.PoisonSoak] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.PoisonHi_I] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.VenomHI_I] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.VenomHI_II] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.PoisonHi_II] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.VenomHI_III] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.Revenge] =       () => {return new Attack_Action();};


        //MA
        ActionDic[E_ActionType.Flame_I] =               () => {return new Attack_Action();};
        ActionDic[E_ActionType.Ice_I] =                 () => {return new Attack_Action();};
        ActionDic[E_ActionType.Thunder_I] =             () => {return new Attack_Action();};
        ActionDic[E_ActionType.FlameBuff] =             () => {return new Attack_Action();};
        ActionDic[E_ActionType.IceBuff] =               () => {return new Attack_Action();};
        ActionDic[E_ActionType.ThunderBuff] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.FlameDefenseDebuff] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.IceDefenseDebuff] =      () => {return new Attack_Action();};
        ActionDic[E_ActionType.ThunderDefenseDebuff] =  () => {return new Attack_Action();};
        ActionDic[E_ActionType.Flame_II] =              () => {return new Attack_Action();};
        ActionDic[E_ActionType.Ice_II] =                () => {return new Attack_Action();};
        ActionDic[E_ActionType.Thunder_II] =            () => {return new Attack_Action();};
        ActionDic[E_ActionType.MagicBuff_II] =          () => {return new Attack_Action();};
        ActionDic[E_ActionType.Cometto] =               () => {return new Attack_Action();};
        ActionDic[E_ActionType.Chaos] =                 () => {return new Attack_Action();};
        ActionDic[E_ActionType.AllMagicBuff] =          () => {return new Attack_Action();};
        ActionDic[E_ActionType.Meteo] =                 () => {return new Attack_Action();};


        //MB
        ActionDic[E_ActionType.FlameDefenseBuff] =              () => {return new Attack_Action();};
        ActionDic[E_ActionType.IceDefenseBuff] =                () => {return new Attack_Action();};
        ActionDic[E_ActionType.ThunderDefenseBuff] =            () => {return new Attack_Action();};
        ActionDic[E_ActionType.FlameDebuff] =                   () => {return new Attack_Action();};
        ActionDic[E_ActionType.IceDebuff] =                     () => {return new Attack_Action();};
        ActionDic[E_ActionType.ThunderDebuff] =                 () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndFlameBuff] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndIceBuff] =             () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndThunderBuff] =         () => {return new Attack_Action();};
        ActionDic[E_ActionType.MPDrain_I] =                     () => {return new Attack_Action();};
        ActionDic[E_ActionType.AntiFlame] =                     () => {return new Attack_Action();};
        ActionDic[E_ActionType.AntiIce] =                       () => {return new Attack_Action();};
        ActionDic[E_ActionType.AntiThunder] =                   () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndAllElementDefenseUP] = () => {return new Attack_Action();};
        ActionDic[E_ActionType.MPDrain_II] =                    () => {return new Attack_Action();};
        ActionDic[E_ActionType.MagicDefense] =                  () => {return new Attack_Action();};
        ActionDic[E_ActionType.HPAndMPDrain] =                  () => {return new Attack_Action();};


        //MS
        ActionDic[E_ActionType.Paralysis_I] =                       () => {return new Attack_Action();};
        ActionDic[E_ActionType.SleepAttack_I] =                     () => {return new Attack_Action();};
        ActionDic[E_ActionType.Paralysis_II] =                      () => {return new Attack_Action();};
        ActionDic[E_ActionType.SleepAttack_II] =                    () => {return new Attack_Action();};
        ActionDic[E_ActionType.ParalysisAttack] =                   () => {return new Attack_Action();};
        ActionDic[E_ActionType.Sleep] =                             () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndParalysisAttackDebuff] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.AtackAndSleepAttackBuff] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndParalysisCure] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.AtackAndSleepTrueAttack] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndParalysisResetStaus] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.AtackAndSleepResetStaus] =           () => {return new Attack_Action();};
        ActionDic[E_ActionType.DefenseAndParalysisDefenseBuff] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.AtackAndSleepMagicBuff] =            () => {return new Attack_Action();};
        ActionDic[E_ActionType.StatusEffectHIAttack] =              () => {return new Attack_Action();};
        


        //SP
        ActionDic[E_ActionType.Regene] =                () => {return new Attack_Action();};

        ActionDic[E_ActionType.MagicBuff_I] =           () => {return new Attack_Action();};

        ActionDic[E_ActionType.AllBuff] =               () => {return new Attack_Action();};
        ActionDic[E_ActionType.CriticalTrueAttack] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.StatusGuard] =           () => {return new Attack_Action();};

        ActionDic[E_ActionType.SelfDestruction] =       () => {return new Attack_Action();};
        ActionDic[E_ActionType.RecoilBuff] =            () => {return new Attack_Action();};


        //Enemy
        ActionDic[E_ActionType.PoisonSlimy] =   () => {return new Attack_Action();};
        ActionDic[E_ActionType.BecomeHard] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.Forward] =       () => {return new Attack_Action();};
        ActionDic[E_ActionType.Anger] =         () => {return new Attack_Action();};

        ActionDic[E_ActionType.FlameWear] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.FlameSlash] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.BoneCurse] =     () => {return new Attack_Action();};

        ActionDic[E_ActionType.VenomBite] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.SleepBite] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.ShutUp] =        () => {return new Attack_Action();};
        ActionDic[E_ActionType.SilenceCurse] =  () => {return new Attack_Action();};
        ActionDic[E_ActionType.SilenceBite] =   () => {return new Attack_Action();};

        ActionDic[E_ActionType.Ironclad] =      () => {return new Attack_Action();};
        ActionDic[E_ActionType.ArmCrush] =      () => {return new Attack_Action();};
        ActionDic[E_ActionType.GuardStyle] =    () => {return new Attack_Action();};

        ActionDic[E_ActionType.Slash] =         () => {return new Attack_Action();};
        ActionDic[E_ActionType.Bomb] =          () => {return new Attack_Action();};
        ActionDic[E_ActionType.Bless] =         () => {return new Attack_Action();};
        ActionDic[E_ActionType.DragonsWakeUp] = () => {return new Attack_Action();};
        ActionDic[E_ActionType.DragonsAnger] =  () => {return new Attack_Action();};
        ActionDic[E_ActionType.ImperialWrath] = () => {return new Attack_Action();};
        ActionDic[E_ActionType.BlackMeteo] =    () => {return new Attack_Action();};


        //そのた
        ActionDic[E_ActionType.Wait] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.ParalysisEffect] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.SleepEffect] =     () => {return new Attack_Action();};
        ActionDic[E_ActionType.SilenceEffect] =    () => {return new Attack_Action();};
        ActionDic[E_ActionType.ArmCrush_NEXT] =    () => {return new Attack_Action();};



    }

    public BattleActorAction CreateAction(E_ActionType type){
        var result = ActionDic[type]();

        if(result is null){
            result = new Attack_Action();
        }

        return result;
    }
}
