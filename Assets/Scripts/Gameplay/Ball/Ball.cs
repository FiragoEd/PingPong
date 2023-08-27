using Gameplay.Ball.CollideProvider;
using Gameplay.Ball.MoveController;
using UnityEngine;

namespace Gameplay.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private BallMoveController _ballMoveController;
        [SerializeField] private BallCollideProvider _ballCollideProvider;

        public BallMoveController BallMoveController => _ballMoveController;
        public BallCollideProvider BallCollideProvider => _ballCollideProvider;
    }
}