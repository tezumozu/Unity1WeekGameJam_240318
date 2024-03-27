using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultSkillInfoUI : MonoBehaviour{
    [SerializeField]
    TextMeshProUGUI skillName;

    [SerializeField]
    TextMeshProUGUI skillText;

    [SerializeField]
    TextMeshProUGUI skillCost;

    
    public void SetInfo(ActionData actionData){
        skillName.text = actionData.SkillName;
        skillText.text = actionData.SkillText;
        skillCost.text = actionData.Cost.ToString();
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);
    }
}
