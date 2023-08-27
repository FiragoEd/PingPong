using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Boosters.BoosterTypes;

namespace Gameplay.Boosters.Factory
{
    
    public class BoosterFactory : IBoosterFactory
    {
        private readonly IEnumerable<BoosterData> _boostersPrefabs;
        private readonly IBallsCreator _ballCreator;
        
        public BoosterFactory(
            IEnumerable<BoosterData> boostersPrefabs,
            IBallsCreator ballCreator)
        {
            _boostersPrefabs = boostersPrefabs;
            _ballCreator = ballCreator;
        }
        public BoosterBase CreateRandomBooster()
        {
            int index = new Random().Next(0, _boostersPrefabs.Count());
            var boosterData = _boostersPrefabs.ElementAt(index);
            var booster = UnityEngine.Object.Instantiate(boosterData.BoosterBasePrefab);
            InitBooster(boosterData.BoosterType,booster);
            return booster;
        }

        private void InitBooster(BoosterType boosterType, BoosterBase boosterBase)
        {
            switch (boosterType)
            {
                case BoosterType.BallDoubler:
                    ((BallDoublerBooster)boosterBase).Construct(_ballCreator);
                    break;
            }
        }
    }
}