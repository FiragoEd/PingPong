using Configs;
using UnityEngine;

namespace Gameplay.Ball.Factory
{
    public sealed class BallFactory : IBallFactory
    {
        private readonly Transform _ballSpawnPoint;
        private readonly BallConfig _ballConfig;
        private readonly Ball _ballPrefabs;

        public BallFactory(
            Transform ballSpawnPoint,
            BallConfig ballConfig,
            Ball prefab)
        {
            _ballSpawnPoint = ballSpawnPoint;
            _ballConfig = ballConfig;
            _ballPrefabs = prefab;
        }

        public Ball CreateBall()
        {
            var ball = Object.Instantiate(_ballPrefabs, _ballSpawnPoint.position, Quaternion.identity);
            ball.BallMoveController.Construct(_ballConfig);
            ball.BallMoveController.AddStartForce();
            return ball;
        }

        public Ball CloneBall(Ball cloneBall)
        {
            var ball = Object.Instantiate(cloneBall, _ballSpawnPoint.position, Quaternion.identity);
            ball.BallMoveController.Construct(_ballConfig);
            ball.BallMoveController.OppositeMove(cloneBall.BallMoveController.Velocity);
            return ball;
        }
    }
}