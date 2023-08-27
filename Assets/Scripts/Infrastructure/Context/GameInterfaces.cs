using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public interface IInitializeListener
    {
        void Initialize();
    }
    
    public interface IDisposeListener
    {
        void Dispose();
    }
    public interface IUpdateGameListener
    {
        void OnUpdate();
    }

    public interface IGameListenerProvider
    {
        IEnumerable<object> GetListeners();
    }
}