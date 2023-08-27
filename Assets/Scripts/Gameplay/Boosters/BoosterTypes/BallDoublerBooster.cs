using Gameplay.Ball.BallAccumulator;

namespace Gameplay.Boosters.BoosterTypes
{
    public class BallDoublerBooster: BoosterBase
    {
        private IBallsCreator _ballCreator;

        public void Construct(IBallsCreator ballsCreator)
        {
            _ballCreator = ballsCreator;
        }
        public override void GetBooster(Player.Player player)
        {
            _ballCreator.CloneBall(_activatedBall);
        }
    }
}