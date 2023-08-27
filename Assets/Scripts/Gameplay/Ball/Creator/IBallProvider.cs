using System;
using System.Collections.Generic;

namespace Gameplay.Ball.BallAccumulator
{
    public interface IBallProvider
    {
        //можно добавить реактивность
        public event Action<Ball> OnBallCreated;
        public List<Ball> Balls { get; }
    }
}