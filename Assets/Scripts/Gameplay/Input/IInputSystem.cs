using System;
using UnityEngine;


namespace Gameplay.Input
{
    public interface IInputSystem
    {
        event Action<Vector2> OnMove;
    }
}