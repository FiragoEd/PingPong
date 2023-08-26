using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public interface IStartGameListener
    {
        void OnStartGame();
    }

    public interface IPauseGameListener
    {
        void OnPauseGame();
    }

    public interface IResumeGameListener
    {
        void OnResumeGame();
    }

    public interface IUpdateGameListener
    {
        void OnUpdate(float deltaTime);
    }
    
    public interface IFinishGameListener
    {
        void OnFinishGame();
    }

    public interface IGameServiceProvider
    {
        IEnumerable<object> GetServices();
    }

    public interface IGameListenerProvider
    {
        IEnumerable<object> GetListeners();
    }
}