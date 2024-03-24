using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionResult{
    public readonly int DamagePoint;
    public readonly List<string> ResultTextList;

    public ActionResult(int damage , List<string> list){
        DamagePoint = damage;
        ResultTextList = list;
    } 
}
