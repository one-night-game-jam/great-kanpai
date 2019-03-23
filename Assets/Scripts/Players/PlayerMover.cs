using UniRx;
using UniRx.Triggers;
using UnityEngine;

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

        void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown("space"))
                .ObserveOn(Scheduler.MainThreadFixedUpdate)
                .Subscribe(_ => rb.AddForce(0, jumpPower, 0, ForceMode.Impulse))
                .AddTo(this);
        }

        void FixedUpdate()
        {
            rb.AddForce(movePower, 0, 0, ForceMode.Acceleration);
        }
    }
}
