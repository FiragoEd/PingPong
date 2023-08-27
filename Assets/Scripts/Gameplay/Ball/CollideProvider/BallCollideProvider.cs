using System;
using Gameplay.DeadZonePlayer;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Ball.CollideProvider
{
    public class BallCollideProvider: MonoBehaviour
    {
        private const string DeadZone_FirstPlayer = "DeadZone1";
        private const string DeadZone_SecondtPlayer = "DeadZone2";
        
        public event Action<PlayerType> OnDeadZoneCollide;
        public event Action<Player.Player> OnPlayerCollide;
        
        //Так себе решение, расплывется в огромный класс
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<DeadZone>(out var deadZone))
            {
                OnDeadZoneCollide?.Invoke(deadZone.PlayerType);
            }
            if (col.gameObject.TryGetComponent<Player.Player>(out var player))
            {
                OnPlayerCollide?.Invoke(player);
            }
        }
    }
}