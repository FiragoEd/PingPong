using System;
using System.Collections.Generic;
using Gameplay.Ball.BallAccumulator;
using Gameplay.GameplayManager.Intrefaces;
using Infrastructure.Context;
using Object = UnityEngine.Object;

namespace Gameplay.Ball.Creator
{
    //можно разделить на партиал классы и туда засунуть реализацию геймплейного ивентабаса
    public sealed class BallsCreator :
        IBallsCreator,
        IBallProvider,
        IStartHandler,
        IFinishRoundHandler,
        IRestartRoundHandler,
        IFinishHandler,
        IInitializeListener,
        IDisposeListener
    {
        private readonly IGameplayListener _gameplayListener;
        private readonly IBallFactory _ballFactory;

        private List<Ball> _balls = new();

        public event Action<Ball> OnBallCreated;
        public event Action<Ball> OnBallRemoved;
        public List<Ball> Balls => _balls;

        public BallsCreator(
            IGameplayListener gameplayListener,
            IBallFactory ballFactory)
        {
            _gameplayListener = gameplayListener;
            _ballFactory = ballFactory;
        }

        public void Initialize()
        {
            _gameplayListener.AddListener(this);
        }

        public void Dispose()
        {
            _gameplayListener.RemoveListener(this);
        }

        public void StartGame()
        {
            InstantiateBall();
        }

        public void RestartRound()
        {
            InstantiateBall();
        }

        public void FinishRound()
        {
            DestroyAllBalls();
        }

        public void FinishGame()
        {
            DestroyAllBalls();
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

        private void DestroyAllBalls()
        {
            foreach (var ball in _balls)
            {
                OnBallRemoved?.Invoke(ball);
                Object.Destroy(ball.gameObject);
            }
            _balls.Clear();
        }
    }
}