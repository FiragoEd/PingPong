using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "RacketData", menuName = "Racket")]
    public class RacketConfig : ScriptableObject
    {
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _sizeCoef;

        public float PlayerSpeed => _playerSpeed;
        public float SizeCoef => _sizeCoef;
    }
}