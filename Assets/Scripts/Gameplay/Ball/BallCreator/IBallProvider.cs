using System;

namespace Gameplay.Ball.BallAccumulator
{
    public interface IBallProvider
    {
        //можно добавить реактивность
        event Action OnBallsChange;
        public Ball GetFirstBall();
    }
}