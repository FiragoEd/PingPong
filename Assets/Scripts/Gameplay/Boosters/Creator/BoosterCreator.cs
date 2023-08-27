using System;
using System.Collections.Generic;
using System.Threading;
using Configs;
using Cysharp.Threading.Tasks;
using Gameplay.Boosters.Factory;
using Gameplay.GameplayManager.Intrefaces;
using Infrastructure.Context;
using Object = UnityEngine.Object;

namespace Gameplay.Boosters.Creator
{
    public class BoosterCreator : 
        IBoosterCreator, 
        IStartHandler, 
        IFinishHandler, 
        IRestartRoundHandler, 
        IFinishRoundHandler ,
        IInitializeListener, 
        IDisposeListener    
    {
        private const int MilliSecondMultiplier = 1000;

        private readonly GameSettingConfig _gameSettingConfig;
        private readonly IGameplayListener _gameplayListener;
        private readonly IBoosterFactory _boosterFactory;

        private List<BoosterBase> _boosters = new();
        private CancellationTokenSource _cancellationToken = new();

        private bool _isSpawning = false;

        public BoosterCreator(
            GameSettingConfig gameSettingConfig,
            IGameplayListener gameplayListener,
            IBoosterFactory boosterFactory)
        {
            _gameSettingConfig = gameSettingConfig;
            _gameplayListener = gameplayListener;
            _boosterFactory = boosterFactory;
        }

        public void Initialize()
        {
            _gameplayListener.AddListener(this);
        }

        public void Dispose()
        {
            _gameplayListener.RemoveListener(this);
        }

        public void StartGame()
        {
            _isSpawning = true;  
            StartSpawningBoosters();
        }

        public void FinishRound()
        {
            _isSpawning = false;
            _cancellationToken?.Cancel();      
            DestroyAllBoosters();
        }

        public void RestartRound()
        {
            _isSpawning = true;
            StartSpawningBoosters();
        }

        public void FinishGame()
        {
            _isSpawning = false;
            _cancellationToken?.Cancel();
            DestroyAllBoosters();       
        }

        public void InstantiateBooster()
        {
            var booster = _boosterFactory.CreateRandomBooster();
            _boosters.Add(booster);
        }

        public void RemoveBooster(BoosterBase booster)
        {
            _boosters.Remove(booster);
            Object.Destroy(booster.gameObject); 
        }

        private void DestroyAllBoosters()
        {
            foreach (var booster in _boosters)
            {
                Object.Destroy(booster.gameObject);
            }
            _boosters.Clear();
        }

        private async void StartSpawningBoosters()
        {
            _cancellationToken = new CancellationTokenSource();
            do
            {
                try
                {
                    await UniTask.Delay(_gameSettingConfig.BoosterSpawning * MilliSecondMultiplier,
                        cancellationToken: _cancellationToken.Token);
                    InstantiateBooster();
                }
                catch
                {
                    // ignored
                }
                
            } while (_isSpawning);
        }
    }
}