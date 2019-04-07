using Managers;
using Players;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    [SerializeField]
    PlayerCore playerPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<PlayerCore.Factory.PlayerSettings, PlayerCore, PlayerCore.Factory>()
            .FromSubContainerResolve()
            .ByNewContextPrefab<PlayerInstaller>(playerPrefab);
        Container.Bind<PlayerSpawner>().AsSingle();
    }
}