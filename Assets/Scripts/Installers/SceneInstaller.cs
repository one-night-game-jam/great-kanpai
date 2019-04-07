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
        Container.BindFactory<PlayerCore.Factory.PlayerSettings, PlayerCore, PlayerCore.Factory>()
            .FromSubContainerResolve()
            .ByNewContextPrefab<PlayerInstaller>(playerPrefabs[0]);
        Container.Bind<PlayerSpawner>().AsSingle();
    }
}