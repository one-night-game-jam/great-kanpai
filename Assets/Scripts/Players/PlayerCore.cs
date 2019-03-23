using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerCore : MonoBehaviour
    {
        [Inject]
        IInputEventProvider inputEventProvider;

        public IObservable<Unit> OnJump => inputEventProvider.Jump
            .WithLatestFrom(Jumpable, (jump, jumpable) => jump && jumpable)
            .Where(b => b)
            .AsUnitObservable();
        public IObservable<float> OnMove => inputEventProvider.Move;
        public IObservable<Unit> OnHit { get; }
        public IObservable<Unit> OnDied { get; }

        IObservable<bool> Jumpable => this.OnTriggerEnterAsObservable()
            .Where(t => t.tag == "JumpableArea")
            .Select(_ => true)
            .Merge(this.OnTriggerExitAsObservable()
                .Where(t => t.tag == "JumpableArea")
                .Select(_ => false));
    }
}
