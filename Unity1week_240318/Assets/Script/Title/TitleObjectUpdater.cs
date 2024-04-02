using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using My1WeekGameSystems_ver2;

public class TitleObjectUpdater : I_SceneObjectUpdatable{

    TitleGameManager gameManager;

   public I_SceneLoadAlertable InitObject(){
       gameManager = new TitleGameManager();
       return gameManager;
   }

   public void StartGame(){

   }

   public void UpdateObject(){

   }

   public void ReleaseObject(){

   }
}
