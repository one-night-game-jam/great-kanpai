using Players;
using Players.InputEventProviderImpls;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [SerializeField]
    bool isPlayer;
    [SerializeField]
    int playerNum;

    public override void InstallBindings()
    {
        if (isPlayer)
        {
            Container.Bind<IInputEventProvider>().To<PlayerInputEventProvider>().AsSingle().WithArguments(playerNum);
        }
        else
        {
            Container.Bind<IInputEventProvider>().To<AiInputEventProvider>().AsSingle();
        }
    }
}