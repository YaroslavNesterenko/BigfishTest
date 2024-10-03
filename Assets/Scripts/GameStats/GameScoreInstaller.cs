using UnityEngine;
using Zenject;

public class GameScoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        GameScoreContainer gameScoreContainer = new GameScoreContainer();
        Container.BindInstance<GameScoreContainer>(gameScoreContainer).AsSingle().NonLazy();
    }
}