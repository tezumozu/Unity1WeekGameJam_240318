using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CheckDesitionNameUI : MonoBehaviour{

    [SerializeField]
    TextMeshProUGUI UIText;

    public void SetName(string text){
        UIText.text = "「 " + text + " 」で よろしいですか？";
    }
}
