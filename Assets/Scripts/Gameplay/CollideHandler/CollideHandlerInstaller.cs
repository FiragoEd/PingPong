using Gameplay.Ball.BallAccumulator;
using Gameplay.Boosters.Creator;
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
            Locator.TryResolve<IBoosterCreator>(out var boosterCreator);

            ICollideHandler collideHandler = new CollideHandler(boosterCreator, ballProvider);
            Locator.Register(collideHandler);
            contextListeners.Add(collideHandler);
        }
    }
}