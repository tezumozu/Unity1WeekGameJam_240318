using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_LearningSkillCheckable {
    public abstract List<E_ActionType> GetLearningSkill(S_SlimeTrainingData data);
}