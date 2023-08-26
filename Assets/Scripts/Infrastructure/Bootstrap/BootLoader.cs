using Infrastructure.ConfigInitializer;
using Infrastructure.InfrastructureFSM;
using Infrastructure.InfrastructureFSM.States;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.Bootstrap
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] private ConfigProvider _configProvider;

        private void Start()
        {
            InitGameStateMachine();
            InitConfigProvider();
        }


        private void InitGameStateMachine()
        {
            var gameStateMachine = new GameStateMachine();
            gameStateMachine.Initialize(new BootstrapState());
            Locator.Register(typeof(IGameStateMachine), gameStateMachine);
        }

        private void InitConfigProvider()
        {
            Locator.Register(typeof(IConfigProvider), _configProvider);
        }
    }
}