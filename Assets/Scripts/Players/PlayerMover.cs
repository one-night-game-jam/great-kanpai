using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        Rigidbody rb;
        [SerializeField]
        float movePower;
        [SerializeField]
        float jumpPower;

        [Inject]
        PlayerCore core;

        void Start()
        {
            core.OnJump
                .ObserveOn(Scheduler.MainThreadFixedUpdate)
                .Subscribe(_ => rb.AddForce(0, jumpPower, 0, ForceMode.Impulse))
                .AddTo(this);

            this.FixedUpdateAsObservable()
                .WithLatestFrom(core.OnMove, (_, f) => f)
                .Subscribe(f => rb.AddForce(movePower * f * Time.deltaTime, 0, 0, ForceMode.Acceleration))
                .AddTo(this);
        }
    }
}
