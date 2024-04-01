using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonData", menuName = "ScriptableObjects/DungeonData")]
public class DungeonData : ScriptableObject {
    [SerializeField]
    public AudioClip BGM;

    [SerializeField]
    public E_EnemyType Enemy;
}
