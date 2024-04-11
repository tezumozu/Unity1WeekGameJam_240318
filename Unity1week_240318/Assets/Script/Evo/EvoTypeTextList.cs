using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EvoTypeTextList", menuName = "ScriptableObjects/EvoTypeTextList", order = 0)]
public class EvoTypeTextList : ScriptableObject {
    [SerializeField]
    public List<EvoTextData> EvoTextList;
}


[Serializable]
public class EvoTextData{
    [SerializeField]
    public E_EvoType Type;

    [SerializeField]
    public List<string> TextList;
}