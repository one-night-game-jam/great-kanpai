using System;
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
            Container.Bind(typeof(IInputEventProvider), typeof(IDisposable))
                .To<PlayerInputEventProvider>()
                .AsSingle()
                .WithArguments(playerNum);
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