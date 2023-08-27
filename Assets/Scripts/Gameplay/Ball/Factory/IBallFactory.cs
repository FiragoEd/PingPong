namespace Gameplay.Ball
{
    public interface IBallFactory
    {
        public Ball CreateBall();
        public Ball CloneBall(Ball cloneBall);
    }
}