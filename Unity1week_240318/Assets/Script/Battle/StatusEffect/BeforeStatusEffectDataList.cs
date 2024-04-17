using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeforeStatusEffectDataList", menuName = "ScriptableObjects/BeforeStatusEffectDataList")]
public class BeforeStatusEffectDataList : ScriptableObject{
    public List<BeforeStatusEffectData> DataList = new List<BeforeStatusEffectData>();
}

[System.Serializable]
public class BeforeStatusEffectData {
    [SerializeField]
    public E_BeforeStatusEffect EffectType;

    [SerializeField]
    public E_ActionType EffectActionType;

    [SerializeField]
    public string EffectName;

    [SerializeField]
    public string EffectText;

    [SerializeField]
    public string EffectAplliyText;

    [SerializeField]
    public string EffectRecoveryText;

    [SerializeField]
    public E_BuffType Type;
}
