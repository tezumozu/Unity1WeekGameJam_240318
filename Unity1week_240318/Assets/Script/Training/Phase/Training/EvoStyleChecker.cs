using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvoStyleChecker{
    private Dictionary<E_Status,EvoStyle> EvoDic;

    public EvoStyleChecker (){
        EvoDic = new Dictionary<E_Status,EvoStyle>();
        EvoDic[E_Status.HP] = new HPStyle();
        EvoDic[E_Status.MP] = new MPStyle();
        EvoDic[E_Status.Attack] = new AttackStyle();
        EvoDic[E_Status.Defense] = new DefenseStyle();
        EvoDic[E_Status.Speed] = new SpeedStyle();
    }

    public EvoStyle CheckEvolve(S_SlimeTrainingData data){

        //優先度順にチェック
        //BADスライム
        if(data.Level == 1){
            return new BadStyle();
        }

        //RAREスライム
        if(data.Level == 100){
            return new RareStyle();
        }

        //その他のスライム
            //最も高いステータスを調べる
        int MaxLevel = 0;
        List<E_Status> MaxStatusList = new List<E_Status>();


        //ここ設計変更で短くできる（アルゴリズムはそのまま）
        if(MaxLevel < data.HPLevel){
            MaxLevel = data.HPLevel;
            MaxStatusList.Clear();
            MaxStatusList.Add(E_Status.HP);
        }else if(MaxLevel == data.HPLevel){
            MaxStatusList.Add(E_Status.HP);
        }


        if(MaxLevel < data.MPLevel){
            MaxLevel = data.MPLevel;
            MaxStatusList.Clear();
            MaxStatusList.Add(E_Status.MP);
        }else if(MaxLevel == data.HPLevel){
            MaxStatusList.Add(E_Status.MP);
        }


        if(MaxLevel < data.AttackLevel){
            MaxLevel = data.AttackLevel;
            MaxStatusList.Clear();
            MaxStatusList.Add(E_Status.Attack);
        }else if(MaxLevel == data.AttackLevel){
            MaxStatusList.Add(E_Status.Attack);
        }

        if(MaxLevel < data.DefenseLevel){
            MaxLevel = data.DefenseLevel;
            MaxStatusList.Clear();
            MaxStatusList.Add(E_Status.Defense);
        }else if(MaxLevel == data.DefenseLevel){
            MaxStatusList.Add(E_Status.Defense);
        }

        if(MaxLevel < data.SpeedLevel){
            MaxLevel = data.SpeedLevel;
            MaxStatusList.Clear();
            MaxStatusList.Add(E_Status.Speed);
        }else if(MaxLevel == data.SpeedLevel){
            MaxStatusList.Add(E_Status.Speed);
        }


        //全てのステータスレベルが一定なら
        if(MaxStatusList.Count == 5){
            return new RareStyle();
        }

        //それ以外ならリストの中からランダムに一つ選ぶ
        var style = MaxStatusList[UnityEngine.Random.Range(0,MaxStatusList.Count)];
        return EvoDic[ style ];
    }

    private enum E_Status{
        HP,
        MP,
        Attack,
        Defense,
        Speed
    }


}
