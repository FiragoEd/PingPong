using System;
using Configs;
using Gameplay.Input;
using UnityEngine;

namespace Gameplay.Player.MoveController
{
    public class PlayerMoveController : MonoBehaviour
    {
        private IInputSystem _inputSystem;
        private RacketConfig _racketConfig;
        private Rigidbody2D _rigidbody2D;

        public void Construct(
            IInputSystem inputSystem,
            RacketConfig racketConfig)

        {
            _inputSystem = inputSystem;
            _racketConfig = racketConfig;
        }

        private void Start()
        {
            _inputSystem.OnMove += OnMoveHandler;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy()
        {
            _inputSystem.OnMove -= OnMoveHandler;
        }

        private void OnMoveHandler(Vector2 direction)
        {
            _rigidbody2D.MovePosition((Vector2)gameObject.transform.position + direction * _racketConfig.PlayerSpeed);
        }
    }
}