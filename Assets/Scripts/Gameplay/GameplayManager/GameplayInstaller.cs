using Gameplay.CollideHandler;
using Gameplay.ScoreManager;
using Infrastructure.Installer;
using Infrastructure.ServiceLocator;

namespace Gameplay.GameplayManager
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void Install()
        {
            BindGameplayManager();
        }

        private void BindGameplayManager()
        {
            Locator.TryResolve<IGameplayStatusProvider>(out var statusProvider);
            Locator.TryResolve<ICollideHandler>(out var collideHandler);
            Locator.TryResolve<IScoreManager>(out var scoreManager);
            IGameplayManager gameplayManager = new GameplayManager(statusProvider, collideHandler, scoreManager);
            Locator.Register(gameplayManager);

            contextListeners.Add(gameplayManager);
        }
    }
}