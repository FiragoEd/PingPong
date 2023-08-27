using System;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Boosters;
using Gameplay.Boosters.Creator;
using Gameplay.Player;
using Infrastructure.Context;
using Object = UnityEngine.Object;

namespace Gameplay.CollideHandler
{
    public class CollideHandler : ICollideHandler, IInitializeListener, IDisposeListener
    {
        private readonly IBallProvider _ballProvider;
        private readonly IBoosterCreator _boosterCreator;

        public event Action<PlayerType> OnDeadZoneCollide;
        
        public CollideHandler(
            IBoosterCreator boosterCreator,
            IBallProvider ballProvider)
        {
            _boosterCreator = boosterCreator;
            _ballProvider = ballProvider;
        }

        public void Initialize()
        {
            _ballProvider.OnBallCreated += OnBallCreatedHandler;
            _ballProvider.OnBallRemoved += OnBallRemoteHandler;
        }
        
        public void Dispose()
        {
            _ballProvider.OnBallCreated -= OnBallCreatedHandler;
            _ballProvider.OnBallRemoved -= OnBallRemoteHandler;
        }
        
        private void OnBallCreatedHandler(Ball.Ball ball)
        {
            ball.BallCollideProvider.OnBoosterCollide += OnBoosterColliderHandler;
            ball.BallCollideProvider.OnDeadZoneCollide += OnDeadZoneCollideHandler;
        }

        private void OnBallRemoteHandler(Ball.Ball ball)
        {
            ball.BallCollideProvider.OnBoosterCollide -= OnBoosterColliderHandler;
            ball.BallCollideProvider.OnDeadZoneCollide -= OnDeadZoneCollideHandler;
        }
        
        private void OnBoosterColliderHandler(BoosterBase booster, Player.Player player)
        {
            booster.GetBooster(player);
            _boosterCreator.RemoveBooster(booster);
        }
        
        private void OnDeadZoneCollideHandler(PlayerType playerZone)
        {
            OnDeadZoneCollide?.Invoke(playerZone);
        }
    }
}