using Players;
using Players.InputEventProviderImpls;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IInputEventProvider>().To<PlayerInputEventProvider>().AsSingle();
    }
}