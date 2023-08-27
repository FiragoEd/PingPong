using System.Collections.Generic;
using Configs;
using Cysharp.Threading.Tasks;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Boosters.Creator;
using Gameplay.Boosters.Factory;
using Gameplay.GameplayManager.Intrefaces;
using Infrastructure.Installer;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Gameplay.Boosters
{
    public class BoostersInstaller : MonoInstaller
    {
        [SerializeField] private List<BoosterData> _boosterPrefabs = new List<BoosterData>();

        private IBoosterFactory _boosterFactory;

        public override void Install()
        {
            BindFactory();
            BindBoosterCreator();
        }

        private void BindFactory()
        {
            Locator.TryResolve<IBallsCreator>(out var ballsCreator);
            _boosterFactory = new BoosterFactory(_boosterPrefabs, ballsCreator);
        }

        private void BindBoosterCreator()
        {
            Locator.TryResolve<GameSettingConfig>(out var gameSettingConfig);
            Locator.TryResolve<IGameplayListener>(out var gameplayListener);
            IBoosterCreator boosterCreator = new BoosterCreator(gameSettingConfig, gameplayListener, _boosterFactory);
            Locator.Register(boosterCreator);

            contextListeners.Add(boosterCreator);
        }
    }
}