using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Ball.BallAccumulator;
using GameSystem;

namespace Gameplay.Ball.BallCreator
{
    public class BallsCreator : IBallsCreator, IBallProvider, IInitializeListener
    {
        private readonly IBallFactory _ballFactory;

        private List<Ball> _balls = new();
        
        public event Action OnBallsChange;
        
        public BallsCreator(IBallFactory ballFactory)
        {
            _ballFactory = ballFactory;
        }
        
        public void Initialize()
        {
            InstantiateBall();
        }

        public void InstantiateBall()
        {
           var ball = _ballFactory.CreateBall();
           _balls.Add(ball);
           OnBallsChange?.Invoke();
        }
        
        public Ball GetFirstBall()
        {
            return _balls.FirstOrDefault();
        }
    }
}