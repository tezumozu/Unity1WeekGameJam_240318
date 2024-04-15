using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GrowUpAnim : MonoBehaviour{

    [SerializeField]
    TextMeshProUGUI Type;

    [SerializeField]
    TextMeshProUGUI Num;


    public void FinishEffect(){
        Destroy(gameObject);
    }

    public void SetEffectText( string type , string num ){
        Type.text = type;
        Num.text = "+" + num;
    }
}
