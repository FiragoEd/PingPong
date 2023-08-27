using Configs;
using Gameplay.Input;
using Gameplay.Player.MoveController;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private PlayerMoveController _playerMoveController;
        
        private RacketConfig _racketConfig;
        
        public PlayerType PlayerType => _playerType;
        public PlayerMoveController PlayerMoveController => _playerMoveController;
        
        public void Construct(RacketConfig racketConfig)
        {
            _racketConfig = racketConfig;
        }

        public void ReduceRacket()
        {
            transform.localScale /= _racketConfig.SizeCoef;
        }

        public void MagnifyRacket()
        {
            transform.localScale *= _racketConfig.SizeCoef;
        }
    }
}