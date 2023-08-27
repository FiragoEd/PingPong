using System;
using GameSystem;
using UnityEngine;

namespace Gameplay.Input.Systems
{
    public sealed class KeyboardInputSystem : IInputSystem, IUpdateGameListener
    {
        public event Action<Vector2> OnMove;
        
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

        public void OnUpdate()
        {
            HandleKeyboard();
        }
    }
}