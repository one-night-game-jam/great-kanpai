using UniRx;
using UnityEngine;
using Zenject;

namespace Players
{
    public class SeEmitter : MonoBehaviour
    {
        [SerializeField]
        AudioSource hit;

        [Inject]
        PlayerCore core;

        void Start()
        {
            core.OnHit
                .Subscribe(_ => hit.Play())
                .AddTo(this);
        }
    }
}
