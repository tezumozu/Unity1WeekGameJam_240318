using UnityEngine;
using Zenject;

using My1WeekGameSystems_ver2;

public class TitleManagerInstaller : MonoInstaller
{
    public override void InstallBindings(){
        Container
            .Bind<I_SceneObjectUpdatable>()
            .To<TitleObjectUpdater>()
            .AsSingle();
    }
}