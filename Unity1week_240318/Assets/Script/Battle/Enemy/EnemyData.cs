using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject{
    [SerializeField]
    public S_BattleActorStatus EnemyStatus;

    [SerializeField]
    public List<E_ActionType> SkillList = new List<E_ActionType>();
}
