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
                .Subscribe(Move)
                .AddTo(this);
        }

        void Move(float x)
        {
            rb.AddForce(movePower * x * Time.deltaTime, 0, 0, ForceMode.Acceleration);

            if (Mathf.Abs(x) < 0.01f) return;
            var lookTarget = 0 < x ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime * 10);
        }
    }
}
