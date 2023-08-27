using System;
using Gameplay.Player;

namespace Gameplay.CollideHandler
{
    public interface ICollideHandler
    {
        public event Action<PlayerType> OnDeadZoneCollide;
    }
}