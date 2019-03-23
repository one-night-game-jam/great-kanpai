using Managers;
using Players;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    [SerializeField]
    PlayerCore[] playerPrefabs;

    public override void InstallBindings()
    {
        Container.Bind<IFactory<PlayerCore.Factory.Type, PlayerCore>>()
            .To<PlayerCore.Factory>()
            .AsSingle()
            .WithArguments(playerPrefabs);
        Container.Bind<PlayerSpawner>().AsSingle();
    }
}