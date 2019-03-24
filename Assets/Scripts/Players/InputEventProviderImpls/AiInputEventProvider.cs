using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Players.InputEventProviderImpls
{
    public class AiInputEventProvider : IInputEventProvider, ITickable
    {
        readonly ReactiveProperty<bool> jump = new ReactiveProperty<bool>();
        readonly ReactiveProperty<float> move = new ReactiveProperty<float>();

        readonly Transform transform;

        IReadOnlyReactiveProperty<bool> IInputEventProvider.Jump => jump;
        IReadOnlyReactiveProperty<float> IInputEventProvider.Move => move;

        float targetPosition;

        AiInputEventProvider(Transform transform)
        {
            this.transform = transform;
        }

        void ITickable.Tick()
        {
            jump.Value = Random.value < (Mathf.Abs(transform.position.x) < 9f ? 0.01f : 0.03f);
            if (Mathf.Abs(targetPosition - transform.position.x) < 1 || Random.value < 0.005f)
            {
                if (Random.value < Mathf.Abs(transform.position.x) * 0.06f)
                {
                    targetPosition = Random.insideUnitCircle.x * 9f;
                }
                else
                {
                    targetPosition = transform.position.x;
                }
            }
            move.Value = Mathf.Clamp(targetPosition - transform.position.x, -1, 1);
        }
    }
}
