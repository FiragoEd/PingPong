using Configs;
using Infrastructure.GameFSM.States;
using Infrastructure.InfrastructureFSM;
using Infrastructure.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Bootstrap
{
    public sealed class BootLoader : MonoBehaviour
    {
        [SerializeField] private RacketConfig _racketConfig;
        [SerializeField] private BotConfig _botConfig;
        [SerializeField] private BallConfig _ballConfig;
        
        private void Start()
        {
            ConfigRegister();
            InitGameStateMachine();
            SceneManager.LoadScene("Scenes/Game");
        }


        private void InitGameStateMachine()
        {
            var gameStateMachine = new GameStateMachine();
            gameStateMachine.Initialize(new BootstrapState());
            Locator.Register(typeof(IGameStateMachine), gameStateMachine);
        }

        private void ConfigRegister()
        {
            Locator.Register(_racketConfig);
            Locator.Register(_botConfig);
            Locator.Register(_ballConfig);
        }
        
    }
}