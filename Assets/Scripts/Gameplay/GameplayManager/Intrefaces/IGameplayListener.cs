namespace Gameplay.GameplayManager.Intrefaces
{
    public interface IGameplayListener
    {
        public void AddListener(IGameplayHandler gameplayHandler);
        public void RemoveListener(IGameplayHandler gameplayHandler);
    }
}