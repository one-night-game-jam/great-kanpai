using System;
using UniRx;
using UnityEngine;

namespace Players.InputEventProviderImpls
{
    public class PlayerInputEventProvider : IInputEventProvider, IDisposable
    {
        readonly ReactiveProperty<bool> jump = new ReactiveProperty<bool>();
        readonly ReactiveProperty<float> move = new ReactiveProperty<float>();
        readonly CompositeDisposable disposable = new CompositeDisposable();

        IReadOnlyReactiveProperty<bool> IInputEventProvider.Jump => jump;
        IReadOnlyReactiveProperty<float> IInputEventProvider.Move => move;

        PlayerInputEventProvider(int playerNum = 0)
        {
            this.ObserveEveryValueChanged(_ => Input.GetButton($"Player{playerNum}Jump"))
                .Subscribe(x => jump.Value = x)
                .AddTo(disposable);
            this.ObserveEveryValueChanged(_ => Input.GetAxis($"Player{playerNum}Horizontal"))
                .Subscribe(x => move.Value = x)
                .AddTo(disposable);
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
