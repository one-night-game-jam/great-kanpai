using Players;
using Players.InputEventProviderImpls;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [SerializeField]
    int playerNum;

    public override void InstallBindings()
    {
        Container.Bind<IInputEventProvider>().To<PlayerInputEventProvider>().AsSingle().WithArguments(playerNum);
    }
}