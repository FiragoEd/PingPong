using Infrastructure.ConfigInitializer;
using Infrastructure.GameFSM.States;
using Infrastructure.InfrastructureFSM;
using Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Bootstrap
{
    public sealed class BootLoader : MonoBehaviour
    {
        [SerializeField] private ConfigProvider _configProvider;

        private void Start()
        {
            InitGameStateMachine();
            InitConfigProvider();
            SceneManager.LoadScene("Scenes/Game");
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