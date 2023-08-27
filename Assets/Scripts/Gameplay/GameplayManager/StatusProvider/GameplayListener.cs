using System.Collections.Generic;
using Gameplay.GameplayManager.Intrefaces;

namespace Gameplay.GameplayManager
{
    public partial class GameplayStatusProvider : IGameplayListener
    {
        private List<IStartHandler> _startHandlers = new();
        private List<IFinishHandler> _finishHandlers = new();
        private List<IRestartRoundHandler> _restartRoundHandlers = new();
        private List<IFinishRoundHandler> _finishRoundHandlers = new();
        
        public void AddListener(IGameplayHandler gameplayHandler)
        {
            if (gameplayHandler is IStartHandler startHandler)
            {
                _startHandlers.Add(startHandler);
            }
            if (gameplayHandler is IFinishHandler finishHandler)
            {
                _finishHandlers.Add(finishHandler);
            }
            if (gameplayHandler is IRestartRoundHandler restartRoundHandler)
            {
                _restartRoundHandlers.Add(restartRoundHandler);
            }
            if (gameplayHandler is IFinishRoundHandler finishRoundHandlers)
            {
                _finishRoundHandlers.Add(finishRoundHandlers);
            }
        }

        public void RemoveListener(IGameplayHandler gameplayHandler)
        {
            if (gameplayHandler is IStartHandler startHandler)
            {
                _startHandlers.Remove(startHandler);
            }
            if (gameplayHandler is IFinishHandler finishHandler)
            {
                _finishHandlers.Remove(finishHandler);
            }
            if (gameplayHandler is IRestartRoundHandler restartRoundHandler)
            {
                _restartRoundHandlers.Remove(restartRoundHandler);
            }
            if (gameplayHandler is IFinishRoundHandler finishRoundHandlers)
            {
                _finishRoundHandlers.Remove(finishRoundHandlers);
            }
        }
    }
}