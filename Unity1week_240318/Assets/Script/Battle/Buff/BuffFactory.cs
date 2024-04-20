using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFactory : I_BuffCreatable{

    public BattleBuff CreateBuff(E_Buff type,int turn){

        BattleBuff buff = new DefenseBuff(turn);

        switch (type){
            case E_Buff.Defense:
                buff = new DefenseBuff(turn);
                break;

            case E_Buff.AttackUP:
                buff = new AttackUPBuff(turn);
                break;

            case E_Buff.AttackDown:
                buff = new AttackDownBuff(turn);
                break;

            case E_Buff.DefenseUP:
                buff = new DefenseUPBuff(turn);
                break;

            case E_Buff.DefenseDown:
                buff = new DefenseDownBuff(turn);
                break;

            case E_Buff.CriticalUP:
                buff = new CriticalUPBuff(turn);
                break;

            case E_Buff.FlameResistanceUP:
                buff = new FlameResistanceUPBuff(turn);
                break;

            case E_Buff.FlameResistanceDown:
                buff = new FlameResistanceDownBuff(turn);
                break;

            case E_Buff.IceResistanceUP:
                buff = new IceResistanceUPBuff(turn);
                break;

            case E_Buff.IceResistanceDown:
                buff = new IceResistanceDownBuff(turn);
                break;

            case E_Buff.ThunderResistanceUP:
                buff = new ThunderResistanceUPBuff(turn);
                break;

            case E_Buff.ThunderResistanceDown:
                buff = new ThunderResistanceDownBuff(turn);
                break;

            case E_Buff.MagicUP:
                buff = new MagicUPBuff(turn);
                break;
            
            case E_Buff.MagicDown:
                buff = new MagicDownBuff(turn);
                break;

            case E_Buff.NormalAttackUP:
                buff = new NormalAttackUPBuff(turn);
                break;

            case E_Buff.NormalAttackDown:
                buff = new NormalAttackDownBuff(turn);
                break;

            default :
                buff = new DefenseBuff(turn);
                break;
            

            case E_Buff.FlameUP:
                buff = new FlameUP(turn);
                break;

            case E_Buff.FlameDown:
                buff = new FlameDown(turn);
                break;

            case E_Buff.IceUP:
                buff = new IceUP(turn);
                break;

            case E_Buff.IceDown:
                buff = new IceDown(turn);
                break;

            case E_Buff.ThunderUP:
                buff = new ThunderUP(turn);
                break;

            case E_Buff.ThunderDown:
                buff = new ThunderDown(turn);
                break;
        }

        return buff;
    }
}
