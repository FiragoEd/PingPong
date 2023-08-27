using System;
using Configs;
using Gameplay.Input;
using UnityEngine;

namespace Gameplay.Player.MoveController
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Renderer))]
    public class PlayerMoveController : MonoBehaviour
    {
        private const float MaxYPos = 4.65f;

        private IInputSystem _inputSystem;
        private RacketConfig _racketConfig;
        private Rigidbody2D _rigidbody2D;
        private Renderer _renderer;

        private bool _isReverse = false;

        public void Construct(
            IInputSystem inputSystem,
            RacketConfig racketConfig)

        {
            _inputSystem = inputSystem;
            _racketConfig = racketConfig;
        }

        public void ReversControl()
        {
            _isReverse = !_isReverse;
        }

        public void SetDefaultControl()
        {
            _isReverse = false;
        }

        private void Start()
        {
            _inputSystem.OnMove += OnMoveHandler;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<Renderer>();
        }

        private void OnDestroy()
        {
            _inputSystem.OnMove -= OnMoveHandler;
        }

        private void OnMoveHandler(Vector2 direction)
        {
            if (_isReverse)
                direction = -direction;
            var movePos = (Vector2)gameObject.transform.position + direction * _racketConfig.PlayerSpeed;

            movePos.y = Math.Clamp(movePos.y, GetClampMinValue(), GetClampMaxValue());
            _rigidbody2D.MovePosition(movePos);
        }

        private float GetClampMinValue()
        {
            return -MaxYPos + _renderer.bounds.extents.y;
        }

        private float GetClampMaxValue()
        {
            return MaxYPos - _renderer.bounds.extents.y;
        }
    }
}