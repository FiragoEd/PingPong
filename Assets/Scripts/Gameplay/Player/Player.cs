using Configs;
using Gameplay.GameplayManager.Intrefaces;
using Gameplay.Player.MoveController;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour, IFinishRoundHandler, IFinishHandler
    {
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private PlayerMoveController _playerMoveController;

        private IGameplayListener _gameplayListener;
        private RacketConfig _racketConfig;

        private Vector3 _startPos;
        private Vector3 _startScale;

        public PlayerType PlayerType => _playerType;
        public PlayerMoveController PlayerMoveController => _playerMoveController;

        public void Construct(
            IGameplayListener gameplayListener,
            RacketConfig racketConfig)
        {
            _gameplayListener = gameplayListener;
            _racketConfig = racketConfig;
        }

        private void Start()
        {
            _gameplayListener.AddListener(this);
            _startPos = transform.position;
            _startScale = transform.localScale;
        }

        public void FinishRound()
        {
            transform.position = _startPos;
            transform.localScale = _startScale;
            _playerMoveController.SetDefaultControl();
        }
        
        public void FinishGame()
        {
            transform.position = _startPos;
            transform.localScale = _startScale;
            _playerMoveController.SetDefaultControl();
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