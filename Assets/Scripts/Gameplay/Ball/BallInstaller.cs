using System.Collections.Generic;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Ball.BallCreator;
using GameSystem;
using Infrastructure.Installer;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Gameplay.Ball
{
    public sealed class BallInstaller : MonoInstaller
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Ball _ballPrefab;

        private IBallFactory _ballFactory;

        public override void Install()
        {
            BindBallFactory();
            BindBallCreator();
        }

        private void BindBallCreator()
        {
            var creator = new BallsCreator(_ballFactory);
            IBallsCreator ballsCreator = creator;
            IBallProvider ballProvider = creator;
            Locator.Register(ballsCreator);
            Locator.Register(ballProvider);
            
            contextListeners.Add(creator);
        }

        private void BindBallFactory()
        {
            _ballFactory = new BallFactory.BallFactory(_spawnPoint, _ballPrefab);
        }
    }
}