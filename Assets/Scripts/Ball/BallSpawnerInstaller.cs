using UnityEngine;
using Zenject;

public class BallSpawnerInstaller : MonoInstaller
{
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private BallsPool ballPools;

    public override void InstallBindings()
    {
        Container.Bind<BallsPool>().FromInstance(ballPools).AsSingle().NonLazy();
        Container.Bind<BallSpawner>().FromInstance(ballSpawner).AsSingle().NonLazy();
    }
}