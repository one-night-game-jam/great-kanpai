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

        public IObservable<Unit> OnHit => this.OnCollisionEnterAsObservable()
            .Where(t => t.collider.tag == "Player")
            .AsUnitObservable();

        public IObservable<Unit> OnDied => this.OnTriggerExitAsObservable()
            .Where(t => t.tag == "PlayArea")
            .Take(1)
            .AsUnitObservable();

        IObservable<bool> Jumpable => this.OnTriggerEnterAsObservable()
            .Where(t => t.tag == "JumpableArea")
            .Select(_ => true)
            .Merge(this.OnTriggerExitAsObservable()
                .Where(t => t.tag == "JumpableArea")
                .Select(_ => false));

        public class Factory : IFactory<Factory.Type, PlayerCore>
        {
            DiContainer container;
            PlayerCore[] prefabs;

            public enum Type
            {
                Player1,
                Player2,
                Ai
            }

            [Inject]
            public void Construct(PlayerCore[] gameObjects, DiContainer container)
            {
                this.container = container;
                prefabs = gameObjects;
            }

            PlayerCore IFactory<Type, PlayerCore>.Create(Type type)
            {
                return container.InstantiatePrefabForComponent<PlayerCore>(prefabs[(int)type]);
            }
        }
    }
}
