using System;
using Configs;
using Gameplay.Ball.BallAccumulator;
using GameSystem;
using UnityEngine;

namespace Gameplay.Input.Systems
{
    public sealed class BotInputSystem :
        IInputSystem,
        IUpdateGameListener,
        IInitializeListener,
        IDisposeListener
    {
        private readonly IBallProvider _ballProvider;
        private readonly Player.Player _player;
        private readonly BotConfig _botConfig;

        public event Action<Vector2> OnMove;

        private Ball.Ball _currentBall = null;

        public BotInputSystem(
            IBallProvider ballProvider,
            Player.Player player)
        {
            _ballProvider = ballProvider;
            _player = player;
        }

        public void Initialize()
        {
            _ballProvider.OnBallsChange += OnBallChangeHandler;
        }

        public void OnUpdate()
        {
            if (_currentBall == null) return;
            
            HandleBallMovment();
        }

        public void Dispose()
        {
            _ballProvider.OnBallsChange -= OnBallChangeHandler;
        }

        private void HandleBallMovment()
        {
            Debug.Log("Handle");
            var ballPos = _currentBall.transform.position;
            var diff = ballPos.y - _player.transform.position.y;
            if (Math.Abs(diff) > 0.5)
                OnMove?.Invoke(diff > 0 ? Vector2.up : Vector2.down);
        }

        private void OnBallChangeHandler()
        {
            _currentBall = _ballProvider.GetFirstBall();
        }
    }
}