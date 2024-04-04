using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class TextBoxManager : MonoBehaviour{
    [SerializeField]
    TextMeshProUGUI Text;

    public void SetText(string text){
        Text.text = text;
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);
    }
}
