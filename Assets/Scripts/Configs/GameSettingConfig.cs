using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameSettingData", menuName = "GameSetting")]
    public class GameSettingConfig : ScriptableObject
    {
        [SerializeField] private int _scoreToWin;
        [SerializeField] private int _secondToGame;
        [SerializeField] private int _boosterSpawning;

        public int ScoreToWin => _scoreToWin;
        public int SecondToGame => _secondToGame;
        public int BoosterSpawning => _boosterSpawning;
    }
}