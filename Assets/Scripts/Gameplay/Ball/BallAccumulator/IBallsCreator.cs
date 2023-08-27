namespace Gameplay.Ball.BallAccumulator
{
    public interface IBallsCreator
    {
        public void InstantiateBall();
        public void CloneBall(Ball ball);
    }
}