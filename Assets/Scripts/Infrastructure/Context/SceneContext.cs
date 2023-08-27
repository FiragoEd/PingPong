using System;
using System.Collections.Generic;
using Infrastructure.Installer;
using UnityEngine;

namespace Infrastructure.Context
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private bool _autoRun = true;
        [SerializeField] private List<MonoInstaller> _monoInstallers;

        private readonly List<IInitializeListener> _initializeListeners = new();
        private readonly List<IUpdateGameListener> _updateListeners = new();
        private readonly List<ILateUpdateGameListener> _lateUpdateListeners = new();
        private readonly List<IDisposeListener> _disposeListeners = new();

        private void Awake()
        {
            if (_autoRun)
                RunContext();
        }

        private void Update()
        {
            for (int i = 0, count = _updateListeners.Count; i < count; i++)
            {
                var listener = _updateListeners[i];
                listener.OnUpdate();
            }
        }

        private void LateUpdate()
        {
            for (int i = 0, count = _lateUpdateListeners.Count; i < count; i++)
            {
                var listener = _lateUpdateListeners[i];
                listener.OnLateUpdate();
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
                this._initializeListeners.Add(initializeListener);
            }
            if (listener is IUpdateGameListener updateListener)
            {
                this._updateListeners.Add(updateListener);
            }
            if (listener is IDisposeListener disposeListener)
            {
                this._disposeListeners.Add(disposeListener);
            }
            if (listener is ILateUpdateGameListener lateUpdateGameListener)
            {
                this._lateUpdateListeners.Add(lateUpdateGameListener);
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
            for (int i = 0, count = _initializeListeners.Count; i < count; i++)
            {
                var listener = _initializeListeners[i];
                listener.Initialize();
            }
        }

        private void InvokeDisposeListeners()
        {
            for (int i = 0, count = _disposeListeners.Count; i < count; i++)
            {
                var listener = _disposeListeners[i];
                listener.Dispose();
            }
        }
    }
}