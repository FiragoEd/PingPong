using System.Collections.Generic;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Input;
using Gameplay.Input.Systems;
using GameSystem;
using Infrastructure.ConfigInitializer;
using Infrastructure.Installer;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayersInstaller : MonoInstaller
    {
        [SerializeField] private Player _player1;
        [SerializeField] private Player _player2;

        

        public override void Install()
        {
            InstallPlayer1();
            InstallPlayer2();
        }

        private void InstallPlayer1()
        {
            IInputSystem inputSystem = new KeyboardInputSystem();
            contextListeners.Add(inputSystem);
            Locator.TryResolve<IConfigProvider>(out var configProvider);

            _player1.PlayerMoveController.Construct(inputSystem, default);
        }

        private void InstallPlayer2()
        {
            Locator.TryResolve<IBallProvider>(out var ballProvider);

            IInputSystem inputSystem = new BotInputSystem(ballProvider,_player2);
            contextListeners.Add(inputSystem);


            _player2.PlayerMoveController.Construct(inputSystem, default);
        }
        
    }
}