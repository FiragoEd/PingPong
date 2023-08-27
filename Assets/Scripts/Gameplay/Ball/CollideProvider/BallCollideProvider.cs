using System;
using Gameplay.Boosters;
using Gameplay.DeadZonePlayer;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Ball.CollideProvider
{
    public class BallCollideProvider : MonoBehaviour
    {
        private const string DeadZone_FirstPlayer = "DeadZone1";
        private const string DeadZone_SecondtPlayer = "DeadZone2";

        private Player.Player _lastPlayerCollide;

        public event Action<PlayerType> OnDeadZoneCollide;
        public event Action<Player.Player> OnPlayerCollide;
        public event Action<BoosterBase,Player.Player> OnBoosterCollide;

        //Так себе решение, расплывется в огромный класс
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent<DeadZone>(out var deadZone))
            {
                OnDeadZoneCollide?.Invoke(deadZone.PlayerType);
            }

            if (col.gameObject.TryGetComponent<Player.Player>(out var player))
            {
                _lastPlayerCollide = player;
                OnPlayerCollide?.Invoke(player);
            }

            if (col.gameObject.TryGetComponent<BoosterBase>(out var booster))
            {
                OnBoosterCollide?.Invoke(booster, _lastPlayerCollide);
            }
        }
    }
}