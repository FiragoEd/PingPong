namespace Gameplay.GameplayManager
{
    public sealed partial class GameplayStatusProvider : IGameplayStatusProvider
    {
        public void StartGame()
        {
            foreach (var startHandler in _startHandlers)
            {
                startHandler.StartGame();
            }
        }

        public void FinishGame()
        {
            foreach (var finishHandler in _finishHandlers)
            {
                finishHandler.FinishGame();
            }
        }

        public void RestartRound()
        {
            foreach (var restartRoundHandler in _restartRoundHandlers)
            {
                restartRoundHandler.RestartRound();
            }
        }

        public void FinishRound()
        {
            foreach (var finishRoundHandler in _finishRoundHandlers)
            {
                finishRoundHandler.FinishRound();
            }
        }
    }
}