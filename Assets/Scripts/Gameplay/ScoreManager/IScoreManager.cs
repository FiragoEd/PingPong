using System;
using Gameplay.Player;

namespace Gameplay.ScoreManager
{
    public interface IScoreManager
    {
        public bool TryIncrementScoreToWin(PlayerType playerType);
        public void ResetScore();
    }
}