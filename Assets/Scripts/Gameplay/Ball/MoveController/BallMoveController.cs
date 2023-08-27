using Configs;
using Gameplay.Ball.CollideProvider;
using UnityEngine;

namespace Gameplay.Ball.MoveController
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BallCollideProvider))]
    public sealed class BallMoveController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private BallCollideProvider _ballCollideProvider;
        private BallConfig _ballConfig;

        public Vector2 Velocity => _rigidbody2D.velocity;

        public void Construct(BallConfig ballConfig)
        {
            _ballConfig = ballConfig;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _ballCollideProvider = GetComponent<BallCollideProvider>();
        }

        private void Start()
        {
            _ballCollideProvider.OnPlayerCollide += OnPlayerCollideHandler;
        }

        private void LateUpdate()
        {
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, _ballConfig.MaxSpeedMagnitude);
        }

        public void AddStartForce()
        {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            var dir = new Vector2(x, y);
            _rigidbody2D.AddForce(dir * _ballConfig.StartSpeed, ForceMode2D.Force);
        }

        public void OppositeMove(Vector2 velocity)
        {
            _rigidbody2D.AddForce(-velocity, ForceMode2D.Force);
        }

        private void OnPlayerCollideHandler(Player.Player player)
        {
            var ballVelocity = _rigidbody2D.velocity + _rigidbody2D.velocity.normalized * _ballConfig.DeltaSpeed;
            _rigidbody2D.velocity = ballVelocity;
        }
    }
}