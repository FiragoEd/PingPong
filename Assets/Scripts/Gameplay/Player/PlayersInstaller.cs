using System.Collections.Generic;
using Configs;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Input;
using Gameplay.Input.Systems;
using Infrastructure.Installer;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayersInstaller : MonoInstaller
    {
        [SerializeField] private Player _player1;
        [SerializeField] private Player _player2;

        private RacketConfig _racketConfig;
        public override void Install()
        {
            Locator.TryResolve<RacketConfig>(out _racketConfig);
            InstallPlayer1();
            InstallPlayer2();
        }

        private void InstallPlayer1()
        {
            IInputSystem inputSystem = new KeyboardInputSystem();
            contextListeners.Add(inputSystem);

            _player1.PlayerMoveController.Construct(inputSystem, _racketConfig);
        }

        private void InstallPlayer2()
        {
            Locator.TryResolve<IBallProvider>(out var ballProvider);
            Locator.TryResolve<BotConfig>(out var botConfig);
            IInputSystem inputSystem = new BotInputSystem(ballProvider, _player2, botConfig);
            contextListeners.Add(inputSystem);

            _player2.PlayerMoveController.Construct(inputSystem, _racketConfig);
        }
    }
}