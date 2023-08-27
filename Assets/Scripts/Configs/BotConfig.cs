using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "BotData", menuName = "Bot")]
    public class BotConfig : ScriptableObject
    {
        [SerializeField] private float _botActiveOffset;

        public float BotActiveOffset => _botActiveOffset;
    }
}