using Players;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class PlayerSpawner
    {
        readonly IFactory<PlayerCore.Factory.Type, PlayerCore> playerFactory;
        readonly Vector3 LeftSideSpawnPoint = new Vector3(-8, 0, 0);
        readonly Vector3 RightSideSpawnPoint = new Vector3(8, 0, 0);

        PlayerSpawner(IFactory<PlayerCore.Factory.Type, PlayerCore> playerFactory)
        {
            this.playerFactory = playerFactory;
        }

        public void SpawnPlayers(GameMode gameMode)
        {
            PlayerCore left = null;
            PlayerCore right = null;
            switch (gameMode)
            {
                case GameMode.OnePlayer:
                    left = playerFactory.Create(PlayerCore.Factory.Type.Player1);
                    right = playerFactory.Create(PlayerCore.Factory.Type.Ai);
                    break;
                case GameMode.TwoPlayer:
                    left = playerFactory.Create(PlayerCore.Factory.Type.Player1);
                    right = playerFactory.Create(PlayerCore.Factory.Type.Player2);
                    break;
            }
            left.gameObject.transform.position = LeftSideSpawnPoint;
            right.gameObject.transform.position = RightSideSpawnPoint;
        }
    }
}
