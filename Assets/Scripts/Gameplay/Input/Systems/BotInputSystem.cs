using System;
using Configs;
using Gameplay.Ball.Creator;
using Gameplay.GameplayManager.Intrefaces;
using Infrastructure.Context;
using UnityEngine;

namespace Gameplay.Input.Systems
{
    public sealed class BotInputSystem :
        IInputSystem,
        ILateUpdateGameListener,
        IStartHandler,
        IFinishHandler,
        IFinishRoundHandler,
        IRestartRoundHandler,
        IInitializeListener,
        IDisposeListener
    {
        private readonly IGameplayListener _gameplayListener;
        private readonly IBallProvider _ballProvider;
        private readonly Player.Player _player;
        private readonly BotConfig _botConfig;


        public event Action<Vector2> OnMove;

        private Ball.Ball _followingBall = null;
        private bool _isHandle = false;

        public BotInputSystem(
            IGameplayListener gameplayListener,
            IBallProvider ballProvider,
            Player.Player player,
            BotConfig botConfig)
        {
            _gameplayListener = gameplayListener;
            _ballProvider = ballProvider;
            _botConfig = botConfig;
            _player = player;
        }

        public void Initialize()
        {
            _gameplayListener.AddListener(this);
        }

        public void Dispose()
        {
            _gameplayListener.RemoveListener(this);
        }

        public void OnLateUpdate()
        {
            if (!_isHandle) return;

            GetFollowingBall();
            if (_followingBall == null) return;
            HandleBallMove();
        }

        public void StartGame()
        {
            _isHandle = true;
        }

        public void FinishRound()
        {
            _followingBall = null;
            _isHandle = false;
        }

        public void RestartRound()
        {
            _isHandle = true;
        }

        public void FinishGame()
        {
            _isHandle = false;
        }

        private void HandleBallMove()
        {
            var ballPos = _followingBall.transform.position;
            var diff = ballPos.y - _player.transform.position.y;
            if (Math.Abs(diff) > _botConfig.BotActiveOffset)
                OnMove?.Invoke(diff > 0 ? Vector2.up : Vector2.down);
        }

        private void GetFollowingBall()
        {
            var minDistance = float.MaxValue;
            _followingBall = null;
            for (var i = 0; i < _ballProvider.Balls.Count; i++)
            {
                var distance = Vector2.Distance(
                    _ballProvider.Balls[i].transform.position,
                    _player.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _followingBall = _ballProvider.Balls[i];
                }
            }
        }
    }
}