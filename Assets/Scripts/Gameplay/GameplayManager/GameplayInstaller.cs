using Configs;
using Gameplay.CollideHandler;
using Gameplay.ScoreManager;
using Infrastructure.Installers;
using Infrastructure.ServiceLocator;
using UI;
using UnityEngine;

namespace Gameplay.GameplayManager
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameFinishPanel _gameFinishPanel;

        public override void Install()
        {
            BindGameplayManager();
        }

        private void BindGameplayManager()
        {
            Locator.TryResolve<IGameplayStatusProvider>(out var statusProvider);
            Locator.TryResolve<ICollideHandler>(out var collideHandler);
            Locator.TryResolve<IScoreManager>(out var scoreManager);
            Locator.TryResolve<GameSettingConfig>(out var gameSettingConfig);
            IGameplayManager gameplayManager =
                new GameplayManager(statusProvider, gameSettingConfig, _gameFinishPanel, collideHandler, scoreManager);
            Locator.Register(gameplayManager);

            contextListeners.Add(gameplayManager);
        }
    }
}