using System;

namespace Gameplay.Boosters.BoosterTypes
{
    public class ReverseControllerBooster : BoosterBase
    {
        public override void GetBooster(Player.Player player)
        {
            player.PlayerMoveController.ReversControl();
        }
    }
}