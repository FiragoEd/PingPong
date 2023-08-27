using Gameplay.GameplayManager.Intrefaces;
using Infrastructure.Installers;
using Infrastructure.ServiceLocator;

namespace Gameplay.GameplayManager.StatusProvider
{
    public class GameplayStatusInstaller : MonoInstaller
    {
        public override void Install()
        {
            var statusProvider = new GameplayStatusProvider();
            IGameplayStatusProvider gameplayStatusProvider = statusProvider;
            IGameplayListener gameplayListener = statusProvider;

            Locator.Register(gameplayListener);
            Locator.Register(gameplayStatusProvider);
        }
    }
}