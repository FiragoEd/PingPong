namespace Gameplay.GameplayManager
{
    public interface IGameplayStatusProvider
    {
        public void StartGame();
        public void FinishGame();
        public void RestartRound();
        public void FinishRound();
    }
}