using UnityEngine;
using Zenject;

using My1WeekGameSystems_ver2;

public class TrainingManagerInstaller : MonoInstaller
{
    public override void InstallBindings(){
        Container
            .Bind<I_SceneObjectUpdatable>()
            .To<TrainingObjectUpdater>()
            .AsSingle();

        Container
            .Bind<TrainingGameManager>()
            .To<TrainingGameManager>()
            .AsSingle();

        Container
            .Bind<SlimeTrainingManager>()
            .To<SlimeTrainingManager>()
            .AsSingle();
    }
}