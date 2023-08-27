namespace Gameplay.Ball.Factory
{
    public interface IBallFactory
    {
        public Ball CreateBall();
        public Ball CloneBall(Ball cloneBall);
    }
}