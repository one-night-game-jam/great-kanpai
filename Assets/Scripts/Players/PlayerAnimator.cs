using UniRx;
using UnityEngine;
using Zenject;

namespace Players
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        Animator animator;

        [Inject]
        PlayerCore core;

        void Start()
        {
            core.OnJump
                .Subscribe(_ => animator.SetTrigger("Jump"))
                .AddTo(this);
        }
    }
}
