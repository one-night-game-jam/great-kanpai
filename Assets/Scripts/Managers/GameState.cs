using System.Collections.Generic;
using System;
using System.Linq;
using UniRx;
using UniRx.Async;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

using Players;
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

        List<PlayerCore> players;

        async void Start()
        {
            await Title();
            // Handle finish of fighting during ready state correctly
            var ready = Ready();
            var fighting = Fighting();
            await ready;
            await fighting;
            await Result();
        }

        async UniTask Title()
        {
            titleUI.gameObject.SetActive(true);
            var gameMode = await titleUI.OnSelectGameMode.First();
            players = playerSpawner.SpawnPlayers(gameMode);
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
            await players.Select(p => p.OnDied).Merge().First();
        }

        async UniTask Result()
        {
            resultUI.gameObject.SetActive(true);
            await resultUI.OnRestartGame.First();
            SceneManager.LoadScene(0);
        }
    }
}
