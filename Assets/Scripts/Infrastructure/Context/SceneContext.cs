using System.Collections.Generic;
using Infrastructure.Installer;
using UnityEngine;

namespace Infrastructure.Context
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private bool _autoRun = true;
        [SerializeField] private List<MonoInstaller> _monoInstallers;

        private readonly List<IInitializeListener> initializeListeners = new();
        private readonly List<IUpdateGameListener> updateListeners = new();
        private readonly List<IDisposeListener> disposeListeners = new();

        private void Awake()
        {
            if (_autoRun)
                RunContext();
        }

        private void Update()
        {
            for (int i = 0, count = updateListeners.Count; i < count; i++)
            {
                var listener = updateListeners[i];
                listener.OnUpdate();
            }
        }

        private void OnDestroy()
        {
            InvokeDisposeListeners();
        }

        private void RunContext()
        {
            InstallBindings();
            InvokeInitListeners();
        }

        private void InstallBindings()
        {
            for (int i = 0; i < _monoInstallers.Count; i++)
            {
                var installer = _monoInstallers[i];

                installer.Install();

                if (installer is IGameListenerProvider listenerProvider)
                    AddListeners(listenerProvider.GetListeners());
            }
        }

        private void AddListener(object listener)
        {
            if (listener is IInitializeListener initializeListener)
            {
                this.initializeListeners.Add(initializeListener);
            }
            if (listener is IUpdateGameListener updateListener)
            {
                this.updateListeners.Add(updateListener);
            }
            if (listener is IDisposeListener disposeListener)
            {
                this.disposeListeners.Add(disposeListener);
            }
        }

        private void AddListeners(IEnumerable<object> listeners)
        {
            foreach (var listener in listeners)
            {
                this.AddListener(listener);
            }
        }

        private void InvokeInitListeners()
        {
            for (int i = 0, count = initializeListeners.Count; i < count; i++)
            {
                var listener = initializeListeners[i];
                listener.Initialize();
            }
        }

        private void InvokeDisposeListeners()
        {
            for (int i = 0, count = disposeListeners.Count; i < count; i++)
            {
                var listener = disposeListeners[i];
                listener.Dispose();
            }
        }
    }
}