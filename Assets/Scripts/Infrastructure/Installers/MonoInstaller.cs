using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.Installer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void InstallBindings();
    }
}