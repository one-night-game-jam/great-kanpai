using System;
using UniRx;
using UnityEngine;

using Managers;

namespace UIs
{
    public class ReadyUI : MonoBehaviour
    {
        [SerializeField]
        float displayDuration;
        public IObservable<Unit> DisplayTimeout => Observable.Timer(TimeSpan.FromMilliseconds(displayDuration)).AsUnitObservable();
    }
}