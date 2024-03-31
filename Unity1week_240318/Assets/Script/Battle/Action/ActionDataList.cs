using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionDataList", menuName = "ScriptableObjects/ActionDataList")]
public class ActionDataList : ScriptableObject{
    public List<ActionData> DataList = new List<ActionData>();
}

[System.Serializable]
public class ActionData {
    [SerializeField]
    public E_ActionType type;

    [SerializeField]
    public int Cost;

    [SerializeField]
    public E_Element Element = E_Element.Non;

    [SerializeField]
    public float CriticalRate = 0.15f;

    [SerializeField]
    public float SuccessRate = 1.0f;

    [SerializeField]
    public bool IsStatusEffectApplicable = false;

    [SerializeField]
    public E_AttackType AttackType;

    [SerializeField]
    public int Power;

    [SerializeField]
    public string SkillName;

    [SerializeField]
    public string SkillText;

    [SerializeField]
    public string ActionSkillText;
}
