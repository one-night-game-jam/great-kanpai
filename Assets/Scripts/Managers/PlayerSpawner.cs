using System.Collections.Generic;
using Players;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class PlayerSpawner
    {
        readonly PlayerCore.Factory playerFactory;
        readonly Vector3 LeftSideSpawnPoint = new Vector3(-8, 0, 0);
        readonly Vector3 RightSideSpawnPoint = new Vector3(8, 0, 0);

        PlayerSpawner(PlayerCore.Factory playerFactory)
        {
            this.playerFactory = playerFactory;
        }

        public List<PlayerCore> SpawnPlayers(GameMode gameMode)
        {
            PlayerCore left = null;
            PlayerCore right = null;
            switch (gameMode)
            {
                case GameMode.OnePlayer:
                    left = playerFactory.Create(new PlayerCore.Factory.PlayerSettings(true, 0));
                    right = playerFactory.Create(new PlayerCore.Factory.PlayerSettings(false, 1));
                    break;
                case GameMode.TwoPlayer:
                    left = playerFactory.Create(new PlayerCore.Factory.PlayerSettings(true, 0));
                    right = playerFactory.Create(new PlayerCore.Factory.PlayerSettings(true, 1));
                    break;
            }
            left.gameObject.transform.position = LeftSideSpawnPoint;
            right.gameObject.transform.position = RightSideSpawnPoint;

            var players = new List<PlayerCore>(2);
            players.Add(left);
            players.Add(right);
            return players;
        }
    }
}
