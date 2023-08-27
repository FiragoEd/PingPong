using System.Collections.Generic;
using GameSystem;
using UnityEngine;

namespace Infrastructure.Installer
{
    public abstract class MonoInstaller : MonoBehaviour, IGameListenerProvider
    {
        protected List<object> contextListeners = new List<object>();
        public abstract void Install();

        public IEnumerable<object> GetListeners()
        {
            return contextListeners;
        }
    }
}