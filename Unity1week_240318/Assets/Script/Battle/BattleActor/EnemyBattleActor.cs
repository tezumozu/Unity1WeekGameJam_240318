using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleActor : BattleActor{

    public EnemyBattleActor(E_EnemyType type){
        //ステータスの生成
        
    }


    public override List<string> CheckBeforeStatusEffect(){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> ActionBattleActor(E_ActionType type,I_DamageApplicable enemy){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> CheckAfterStatusEffect(){
        var resultTextList = new List<string>();

        return resultTextList;
    }


    public override List<string> RefreshBattleActor(){
        var resultTextList = new List<string>();

        return resultTextList;
    }

    //ランダムで行動が必要な時用(混乱時など)
    protected List<string> ActionBattleActor(I_DamageApplicable enemy){
        var resultTextList = new List<string>();

        return resultTextList;
    }
}
