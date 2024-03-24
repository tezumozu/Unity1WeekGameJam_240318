using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_ActionCreatable {
    public abstract BattleActorAction CreateAction(E_ActionType type);
}
