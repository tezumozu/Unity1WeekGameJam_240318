using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTextManager : MonoBehaviour{

    Text textObject;

    private void Start() {
        textObject = gameObject.transform.Find("TextBox/Text").gameObject.GetComponent<Text>();
    }

    public void SetText(string text){
        textObject.text = text;
    }
}
