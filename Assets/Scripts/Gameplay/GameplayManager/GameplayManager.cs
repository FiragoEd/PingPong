using System;
using System.Threading;
using Configs;
using Cysharp.Threading.Tasks;
using Gameplay.CollideHandler;
using Gameplay.Player;
using Gameplay.ScoreManager;
using Infrastructure.Context;
using UI;

namespace Gameplay.GameplayManager
{
    public class GameplayManager : IGameplayManager, IInitializeListener, IDisposeListener
    {
        private const int DelayBetweenRound = 700;

        private readonly IGameplayStatusProvider _gameplayStatusProvider;
        private readonly GameSettingConfig _gameSettingConfig;
        private readonly GameFinishPanel _gameFinishPanel;
        private readonly ICollideHandler _collideHandler;
        private readonly IScoreManager _scoreManager;

        private CancellationTokenSource _cancellationTokenSource = new();

        public GameplayManager(
            IGameplayStatusProvider gameplayStatusProvider,
            GameSettingConfig gameSettingConfig,
            GameFinishPanel gameFinishPanel,
            ICollideHandler collideHandler,
            IScoreManager scoreManager)

        {
            _gameplayStatusProvider = gameplayStatusProvider;
            _gameSettingConfig = gameSettingConfig;
            _gameFinishPanel = gameFinishPanel;
            _collideHandler = collideHandler;
            _scoreManager = scoreManager;
        }

        public void Initialize()
        {
            _collideHandler.OnDeadZoneCollide += OnDeadZoneCollideHandler;
            _gameFinishPanel.RestartButton.onClick.AddListener(OnUIRestartButton);

            StartGame();
        }

        public void Dispose()
        {
            _collideHandler.OnDeadZoneCollide -= OnDeadZoneCollideHandler;
        }

        private async void OnDeadZoneCollideHandler(PlayerType playerType)
        {
            if (_scoreManager.TryIncrementScoreToWin(playerType))
            {
                FinishGame(playerType);
            }
            else
            {
                _gameplayStatusProvider.FinishRound();
                await UniTask.Delay(DelayBetweenRound);
                _gameplayStatusProvider.RestartRound();
            }
        }

        private void FinishGame(PlayerType playerType)
        {
            _gameplayStatusProvider.FinishGame();
            _gameFinishPanel.gameObject.SetActive(true);
            _gameFinishPanel.SetWinner(playerType);
        }

        private void StartGame()
        {
            _scoreManager.ResetScore();
            _gameplayStatusProvider.StartGame();
            _gameFinishPanel.gameObject.SetActive(false);
        }

        private void OnUIRestartButton()
        {
            StartGame();
            SetTimer();
        }

        private async void SetTimer()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                await UniTask.Delay(_gameSettingConfig.SecondToGame * 1000,
                    cancellationToken: _cancellationTokenSource.Token);
                FinishGame((PlayerType)Int32.MaxValue);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}