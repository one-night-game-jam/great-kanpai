using UniRx.Async;
using UnityEngine;

namespace GameState
{
    public class GameState : MonoBehaviour
    {
        // [SerializeField]
        // TitleUI titleUI;

        // [SerializeField]
        // ReadyUI titleUI;

        // [SerializeField]
        // ResultUI resultUI;

        async void Start()
        {
            await Title();
            await Ready();
            await Fighting();
            await Result();
        }

        async UniTask Title()
        {
            // TODO: Await game mode selection
            // TODO: Instantiate players
        }

        async UniTask Ready()
        {
            // TODO: Show/Hide ready UI
        }

        async UniTask Fighting()
        {
            // TODO: Enable player inputs
            // TODO: Await game finish
            // TODO: Disable player inputs
        }

        async UniTask Result()
        {
            // TODO: Display result
            // TODO: Await reload button
            // TODO: Reload the scene
        }
    }
}
