using UnityEngine;
using Zenject;

using My1WeekGameSystems_ver2;

public class EvoInstoller : MonoInstaller
{
    public override void InstallBindings(){
        Container
            .Bind<I_SceneObjectUpdatable>()
            .To<EvoGameObjectUpdater>()
            .AsSingle();

        Container
            .Bind<EvoGameManager>()
            .To<EvoGameManager>()
            .AsSingle();
    }
}