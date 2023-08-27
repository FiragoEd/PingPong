using Configs;
using Gameplay.Ball.Creator;
using Gameplay.GameplayManager.Intrefaces;
using Gameplay.Input;
using Gameplay.Input.Systems;
using Infrastructure.Installers;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayersInstaller : MonoInstaller
    {
        [SerializeField] private Player _player1;
        [SerializeField] private Player _player2;

        private RacketConfig _racketConfig;
        private IGameplayListener _gameplayListener;

        public override void Install()
        {
            ResolveDependencies();
            InstallPlayer1();
            InstallPlayer2();
        }

        private void ResolveDependencies()
        {
            Locator.TryResolve<RacketConfig>(out _racketConfig);
            Locator.TryResolve<IGameplayListener>(out _gameplayListener);
        }


        private void InstallPlayer1()
        {
            IInputSystem inputSystem = new KeyboardInputSystem(_gameplayListener);
            contextListeners.Add(inputSystem);

            _player1.PlayerMoveController.Construct(inputSystem, _racketConfig);
            _player1.Construct(_gameplayListener, _racketConfig);

            contextListeners.Add(inputSystem);
        }

        private void InstallPlayer2()
        {
            Locator.TryResolve<IBallProvider>(out var ballProvider);
            Locator.TryResolve<BotConfig>(out var botConfig);
            IInputSystem inputSystem = new BotInputSystem(_gameplayListener, ballProvider, _player2, botConfig);
            contextListeners.Add(inputSystem);

            _player2.PlayerMoveController.Construct(inputSystem, _racketConfig);
            _player2.Construct(_gameplayListener, _racketConfig);
        }
    }
}