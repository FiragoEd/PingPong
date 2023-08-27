using System;
using Configs;
using Gameplay.Ball.BallAccumulator;
using GameSystem;
using UnityEngine;

namespace Gameplay.Input.Systems
{
    public sealed class BotInputSystem :
        IInputSystem,
        IUpdateGameListener
    {
        private readonly IBallProvider _ballProvider;
        private readonly Player.Player _player;
        private readonly BotConfig _botConfig;

        public event Action<Vector2> OnMove;

        private Ball.Ball _followingBall = null;

        public BotInputSystem(
            IBallProvider ballProvider,
            Player.Player player,
            BotConfig botConfig)
        {
            _ballProvider = ballProvider;
            _botConfig = botConfig;
            _player = player;
        }

        public void OnUpdate()
        {
            GetFollowingBall();
            if (_followingBall == null) return;
            HandleBallMove();
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