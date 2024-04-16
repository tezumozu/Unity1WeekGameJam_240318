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

    [SerializeField]
    Image icon;

    [SerializeField]
    Sprite AttackIcon;

    [SerializeField]
    Sprite MagicIcon;

    
    public void SetInfo(ActionData actionData){
        skillName.text = actionData.SkillName;
        skillText.text = actionData.SkillText;
        skillCost.text = actionData.Cost.ToString();

        if(actionData.AttackType == E_AttackType.Attack){
            icon.sprite = AttackIcon;
        }else{
            icon.sprite = MagicIcon;
        }
    }

    public void SetActive(bool flag){
        gameObject.SetActive(flag);
    }
}
