using System.Collections.Generic;
using System.Linq;
using Infrastructure.Installer;
using UnityEngine;

namespace Infrastructure.Context
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private bool _autoRun = true;
        [SerializeField] private List<MonoInstaller> _monoInstallers;

        private void Awake()
        {
            if (_autoRun)
                RunContext();
        }

        private void RunContext()
        {
            InstallBindings();
        }
        
        private void InstallBindings()
        {
            for (int i = 0; i < _monoInstallers.Count; i++)
            {
                _monoInstallers[i].InstallBindings();
            }
        }
    }
}