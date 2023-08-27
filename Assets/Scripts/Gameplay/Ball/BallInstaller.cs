using System.Collections.Generic;
using Configs;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Ball.Creator;
using Gameplay.Ball.Factory;
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
            Locator.TryResolve<BallConfig>(out var ballConfig);
            _ballFactory = new BallFactory(_spawnPoint, ballConfig, _ballPrefab);
        }
    }
}