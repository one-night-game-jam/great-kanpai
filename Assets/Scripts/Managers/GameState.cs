using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

using UIs;

namespace Managers
{
    public class GameState : MonoBehaviour
    {
        [Inject]
        TitleUI titleUI;

        [Inject]
        ReadyUI readyUI;

        [Inject]
        ResultUI resultUI;

        [Inject]
        PlayerSpawner playerSpawner;

        async void Start()
        {
            await Title();
            await Ready();
            await Fighting();
            await Result();
        }

        async UniTask Title()
        {
            titleUI.gameObject.SetActive(true);
            var gameMode = await titleUI.OnSelectGameMode.First();
            playerSpawner.SpawnPlayers(gameMode);
            titleUI.gameObject.SetActive(false);
        }

        async UniTask Ready()
        {
            readyUI.gameObject.SetActive(true);
            await readyUI.DisplayTimeout.First();
            readyUI.gameObject.SetActive(false);
        }

        async UniTask Fighting()
        {
            // TODO: Enable player inputs
            // TODO: Await game finish
            // TODO: Disable player inputs
        }

        async UniTask Result()
        {
            resultUI.gameObject.SetActive(true);
            await resultUI.OnRestartGame.First();
            SceneManager.LoadScene(0);
        }
    }
}
