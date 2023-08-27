using Configs;
using Infrastructure.Installers;
using Infrastructure.ServiceLocator;
using TMPro;
using UnityEngine;

namespace Gameplay.ScoreManager
{
    public class ScoreInstaller : MonoInstaller
    {
        [SerializeField] private TMP_Text _player1Text;
        [SerializeField] private TMP_Text _player2Text;

        public override void Install()
        {
            BindScoreManager();
        }

        private void BindScoreManager()
        {
            Locator.TryResolve<GameSettingConfig>(out var gameSettingConfig);

            IScoreManager scoreManager = new ScoreManager(gameSettingConfig, _player1Text, _player2Text);
            Locator.Register(scoreManager);
        }
    }
}