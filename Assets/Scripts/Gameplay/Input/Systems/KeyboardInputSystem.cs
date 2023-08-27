using System;
using Gameplay.GameplayManager.Intrefaces;
using Infrastructure.Context;
using UnityEngine;

namespace Gameplay.Input.Systems
{
    public sealed class KeyboardInputSystem :
        IInputSystem,
        IUpdateGameListener,
        IStartHandler,
        IFinishHandler,
        IInitializeListener,
        IDisposeListener
    {
        private readonly IGameplayListener _gameplayListener;

        private bool _isHandle = false;
        public event Action<Vector2> OnMove;

        public KeyboardInputSystem(IGameplayListener gameplayListener)
        {
            _gameplayListener = gameplayListener;
        }

        public void Initialize()
        {
            _gameplayListener.AddListener(this);
        }

        public void Dispose()
        {
            _gameplayListener.RemoveListener(this);
        }

        public void OnUpdate()
        {
            if (_isHandle)
                HandleKeyboard();
        }

        public void StartGame()
        {
            _isHandle = true;
        }

        public void FinishGame()
        {
            _isHandle = false;
        }

        private void HandleKeyboard()
        {
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
            {
                OnMove?.Invoke(Vector2.up);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
            {
                OnMove?.Invoke(Vector2.down);
            }
        }
    }
}