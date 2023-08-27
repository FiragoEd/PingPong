using Configs;
using Gameplay.Player;
using TMPro;

namespace Gameplay.ScoreManager
{
    public class ScoreManager : IScoreManager
    {
        private readonly GameSettingConfig _gameSettingConfig;
        private readonly TMP_Text _fistPlayerText;
        private readonly TMP_Text _secondPlayerText;

        private int _fistPlayerScore = 0;
        private int _secondPlayerScore = 0;
        
        public ScoreManager(
            GameSettingConfig gameSettingConfig,
            TMP_Text fistPlayerText,
            TMP_Text secondPlayerText)
        {
            _gameSettingConfig = gameSettingConfig;

            _fistPlayerText = fistPlayerText;
            _secondPlayerText = secondPlayerText;
        }

        public void ResetScore()
        {
            _fistPlayerScore = 0;
            _secondPlayerScore = 0;

            _fistPlayerText.text = _fistPlayerScore.ToString();
            _secondPlayerText.text = _fistPlayerScore.ToString();
        }
        
        public bool TryIncrementScoreToWin(PlayerType playerType)
        {
            if (playerType == PlayerType.First)
            {
                _fistPlayerScore++;
                _fistPlayerText.text = _fistPlayerScore.ToString();
                if (_fistPlayerScore == _gameSettingConfig.ScoreToWin)
                    return true;
            }
            else
            {
                _secondPlayerScore++;
                _secondPlayerText.text = _fistPlayerScore.ToString();
                if(_secondPlayerScore == _gameSettingConfig.ScoreToWin)
                    return true;
            }

            return false;
        }
    }
}