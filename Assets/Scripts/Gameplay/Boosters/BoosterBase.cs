using UnityEngine;

namespace Gameplay.Boosters
{
    public abstract class BoosterBase : MonoBehaviour
    {
        protected Ball.Ball _activatedBall;
        public abstract void GetBooster(Player.Player player);

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<Ball.Ball>(out var ball))
            {
                _activatedBall = ball;
            }
        }
    }
}