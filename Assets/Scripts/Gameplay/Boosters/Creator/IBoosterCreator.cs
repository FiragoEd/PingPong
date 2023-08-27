namespace Gameplay.Boosters.Creator
{
    public interface IBoosterCreator
    {
        public void InstantiateBooster();
        public void RemoveBooster(BoosterBase booster);
    }
}