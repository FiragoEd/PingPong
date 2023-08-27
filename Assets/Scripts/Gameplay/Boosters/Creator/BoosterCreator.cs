using System.Collections.Generic;
using Gameplay.Boosters.Factory;

namespace Gameplay.Boosters.Creator
{
    public class BoosterCreator : IBoosterCreator
    {
        private readonly IBoosterFactory _boosterFactory;

        private List<BoosterBase> _boosters = new();

        public BoosterCreator(IBoosterFactory boosterFactory)
        {
            _boosterFactory = boosterFactory;
        }

        public void InstantiateBooster()
        {
            var booster = _boosterFactory.CreateRandomBooster();
            _boosters.Add(booster);
        }
    }
}