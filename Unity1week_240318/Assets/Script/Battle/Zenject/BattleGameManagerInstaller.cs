using UnityEngine;
using Zenject;

using My1WeekGameSystems_ver2;

public class BattleGameManagerInstaller : MonoInstaller
{
    public override void InstallBindings(){
        Container
            .Bind<I_SceneObjectUpdatable>()
            .To<BattleObjectUpdater>()
            .AsSingle();
    }
}