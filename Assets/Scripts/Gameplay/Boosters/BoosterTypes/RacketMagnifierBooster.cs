namespace Gameplay.Boosters.BoosterTypes
{
    public class RacketMagnifierBooster : BoosterBase
    {
        public override void GetBooster(Player.Player player)
        {
            player.MagnifyRacket();
        }
    }
}