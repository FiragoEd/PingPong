using System;
using System.Collections.Generic;

namespace Gameplay.Ball.Creator
{
    public interface IBallProvider
    {
        //можно добавить реактивность
        public event Action<Ball> OnBallCreated;
        public event Action<Ball> OnBallRemoved;

        public List<Ball> Balls { get; }
    }
}