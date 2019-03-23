using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerCore : MonoBehaviour
    {
        [Inject]
        IInputEventProvider inputEventProvider;

        public IObservable<Unit> OnJump => inputEventProvider.Jump.Where(b => b).AsUnitObservable();
        public IObservable<float> OnMove => inputEventProvider.Move;
        public IObservable<Unit> OnHit { get; }
        public IObservable<Unit> OnDied { get; }
    }
}
