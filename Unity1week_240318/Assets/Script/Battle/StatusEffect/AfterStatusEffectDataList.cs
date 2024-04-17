using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AfterStatusEffectDataList", menuName = "ScriptableObjects/AfterStatusEffectDataList")]
public class AfterStatusEffectDataList : ScriptableObject{
    public List<AfterStatusEffectData> DataList = new List<AfterStatusEffectData>();
}

[System.Serializable]
public class AfterStatusEffectData {
    [SerializeField]
    public E_AfterStatusEffect EffectType;

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
