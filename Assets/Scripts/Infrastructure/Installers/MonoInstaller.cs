using System.Collections.Generic;
using Infrastructure.Context;
using UnityEngine;

namespace Infrastructure.Installers
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