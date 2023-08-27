using Cysharp.Threading.Tasks;
using Gameplay.CollideHandler;
using Gameplay.Player;
using Gameplay.ScoreManager;
using Infrastructure.Context;

namespace Gameplay.GameplayManager
{
    public class GameplayManager : IGameplayManager , IInitializeListener, IDisposeListener
    {
        private const int DelayBetweenRound = 500;
        
        private readonly IGameplayStatusProvider _gameplayStatusProvider;
        private readonly ICollideHandler _collideHandler;
        private readonly IScoreManager _scoreManager;
        
        public GameplayManager(
            IGameplayStatusProvider gameplayStatusProvider,
            ICollideHandler collideHandler,
            IScoreManager scoreManager)
        
        {
            _gameplayStatusProvider = gameplayStatusProvider;
            _collideHandler = collideHandler;
            _scoreManager = scoreManager;
           
        }

        public void Initialize()
        {
            _gameplayStatusProvider.StartGame();
            _collideHandler.OnDeadZoneCollide += OnDeadZoneCollideHandler;
        }

        public void Dispose()
        {
            _collideHandler.OnDeadZoneCollide -= OnDeadZoneCollideHandler;
        }
        
        private async void OnDeadZoneCollideHandler(PlayerType playerType)
        {

            if (_scoreManager.TryIncrementScoreToWin(playerType))
            {
                _gameplayStatusProvider.FinishGame();
            }
            else
            {
                _gameplayStatusProvider.FinishRound();
                await UniTask.Delay(DelayBetweenRound);
                _gameplayStatusProvider.RestartRound();
            }
        }
    }
}