using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(fileName = "BallData", menuName = "Ball")]
    public class BallConfig: ScriptableObject
    {
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _deltaSpeed;
        [SerializeField] private float _maxSpeedMagnitude;
        
        public float StartSpeed => _startSpeed;
        public float DeltaSpeed => _deltaSpeed;
        public float MaxSpeedMagnitude => _maxSpeedMagnitude;
    }
}