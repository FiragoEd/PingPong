using Gameplay.Player;
using UnityEngine;

namespace Gameplay.DeadZonePlayer
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private PlayerType _playerType;

        public PlayerType PlayerType => _playerType;
    }
}