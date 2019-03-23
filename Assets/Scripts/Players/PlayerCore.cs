using System;
using UniRx;
using UnityEngine;

namespace Players
{
    public class PlayerCore : MonoBehaviour
    {
        public IObservable<Unit> OnJump { get; }
        public IObservable<bool> OnMove { get; }
        public IObservable<Unit> OnHit { get; }
        public IObservable<Unit> OnDied { get; }
    }
}
