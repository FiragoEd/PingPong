using Gameplay.Ball.BallAccumulator;
using Infrastructure.Installer;
using Infrastructure.ServiceLocator;

namespace Gameplay.CollideHandler
{
    public class CollideHandlerInstaller : MonoInstaller
    {
        public override void Install()
        {
            BindCollideHandler();
        }

        private void BindCollideHandler()
        {
            Locator.TryResolve<IBallProvider>(out var ballProvider);

            ICollideHandler collideHandler = new CollideHandler(ballProvider);
            Locator.Register(collideHandler);
            contextListeners.Add(collideHandler);
        }
    }
}