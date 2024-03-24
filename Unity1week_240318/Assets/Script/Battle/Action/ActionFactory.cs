using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFactory : I_ActionCreatable{
    public BattleActorAction CreateAction(E_ActionType type){
        BattleActorAction action = null;

        switch (type){
            case E_ActionType.Attack :
                action = new Attack_Action();
                break;
            
            default:
                action = new Attack_Action();
                break;
        }
        return action;
    }
}
