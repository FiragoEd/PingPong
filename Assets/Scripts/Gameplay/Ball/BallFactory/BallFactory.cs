using Gameplay.Ball.BallAccumulator;
using UnityEngine;

namespace Gameplay.Ball.BallFactory
{
    public sealed class BallFactory : IBallFactory
    {
        private readonly Transform _ballSpawnPoint;
        private readonly Ball _ballPrefabs;

        public BallFactory(
            Transform ballSpawnPoint,
            Ball prefab)
        {
            _ballSpawnPoint = ballSpawnPoint;
            _ballPrefabs = prefab;
        }

        public Ball CreateBall()
        {
            var ball = Object.Instantiate(_ballPrefabs, _ballSpawnPoint.position, Quaternion.identity);

            return ball;
        }
    }
}