using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoUIManager : MonoBehaviour{
    [SerializeField]
    Text skillName;

    [SerializeField]
    Text skillText;

    [SerializeField]
    Text skillCost;

    
    public void SetInfo(ActionData actionData){
        skillName.text = actionData.SkillName;
        skillText.text = actionData.SkillText;
        skillCost.text = actionData.Cost.ToString();
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);
    }
}
