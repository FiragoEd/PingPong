using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gameplay.Ball.BallAccumulator;
using GameSystem;

namespace Gameplay.Ball.Creator
{
    public sealed class BallsCreator : IBallsCreator, IBallProvider, IInitializeListener
    {
        private readonly IBallFactory _ballFactory;

        private List<Ball> _balls = new();

        public event Action<Ball> OnBallCreated;
        public List<Ball> Balls => _balls;

        public BallsCreator(IBallFactory ballFactory)
        {
            _ballFactory = ballFactory;
        }

        public async void Initialize()
        {
            await UniTask.Delay(100);
            InstantiateBall();
        }

        public void InstantiateBall()
        {
            var ball = _ballFactory.CreateBall();
            _balls.Add(ball);
            OnBallCreated?.Invoke(ball);
        }

        public void CloneBall(Ball cloneBall)
        {
            var ball = _ballFactory.CloneBall(cloneBall);
            _balls.Add(ball);
            OnBallCreated?.Invoke(ball);
        }
    }
}