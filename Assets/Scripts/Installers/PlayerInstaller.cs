using System;
using Players;
using Players.InputEventProviderImpls;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [Inject]
    PlayerCore.Factory.PlayerSettings settings;

    public override void InstallBindings()
    {
        if (settings.IsPlayer)
        {
            Container.Bind(typeof(IInputEventProvider), typeof(IDisposable))
                .To<PlayerInputEventProvider>()
                .AsSingle()
                .WithArguments(settings.PlayerNum);
        }
        else
        {
            Container.Bind(typeof(IInputEventProvider), typeof(ITickable))
                .To<AiInputEventProvider>()
                .AsSingle()
                .WithArguments(transform);
        }
    }
}
