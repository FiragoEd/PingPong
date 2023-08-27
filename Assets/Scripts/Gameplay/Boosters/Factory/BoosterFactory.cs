using System.Collections.Generic;
using System.Linq;
using Gameplay.Ball.BallAccumulator;
using Gameplay.Boosters.BoosterTypes;
using UnityEngine;

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
            int index = Random.Range(0, _boostersPrefabs.Count());
            var boosterData = _boostersPrefabs.ElementAt(index);
            var position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), -1);
            var booster = UnityEngine.Object.Instantiate(boosterData.BoosterBasePrefab, position, Quaternion.identity);
            InitBooster(boosterData.BoosterType, booster);
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