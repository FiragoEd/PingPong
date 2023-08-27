using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "RacketData", menuName = "Racket")]
    public class RacketConfig : ScriptableObject
    {
        [SerializeField] private float _playerSpeed;

        public float PlayerSpeed => _playerSpeed;
    }
}