using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Boosters.Creator;
using Gameplay.Boosters.Factory;
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

        private async void BindBoosterCreator()
        {
            IBoosterCreator boosterCreator = new BoosterCreator(_boosterFactory);
            Locator.Register(boosterCreator);
            await UniTask.Delay(5000);
            boosterCreator.InstantiateBooster();
        }
    }
}