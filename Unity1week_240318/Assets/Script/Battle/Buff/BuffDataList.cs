using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffDataList", menuName = "ScriptableObjects/BuffDataList")]
public class BuffDataList : ScriptableObject{
    public List<BuffData> DataList = new List<BuffData>();
}

[System.Serializable]
public class BuffData {
    [SerializeField]
    public E_Buff BuffType;

    [SerializeField]
    public string BuffName;

    [SerializeField]
    public string BuffText;

    [SerializeField]
    public string BuffAplliyText;
}
