using System;
using FishGame.Core.Fish;
using FishGame.Gameplay;
using FishGame.Utilities;
using UnityEngine;

namespace FishGame
{
    public class Main : Singleton<Main>
    {
        private const string FishAssetPath = "Prefabs/Fish";
        private const string SpawnerAssetPath = "Prefabs/FishSpawner";
        private const string ContainerAssetPath = "SO/FishAssetContainer";

        public const int InitialFishCount = 3;

        public Fish FishAsset { get; private set; }
        public FishSpawner SpawnerAsset { get; private set; }
        public FishAssetContainer ContainerAsset { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
 
        private void Start()
        {
            LoadFishAsset();
            LoadSpawnerAsset();
            LoadAssetContainerAsset();
        }

        private void LoadFishAsset()
        {
            var assetContainerReference = Resources.Load<Fish>(FishAssetPath);
            
            if (assetContainerReference != null)
            {
                FishAsset = assetContainerReference;
            }

            else
            {
                Debug.LogError("[FishGame::Main::LoadFishAsset -> Fish couldn't be loaded from Resources folder!");
                throw new NullReferenceException();
            }
        }

        private void LoadSpawnerAsset()
        {
            var spawnerAssetReference = Resources.Load<FishSpawner>(SpawnerAssetPath);

            if (spawnerAssetReference != null)
            {
                SpawnerAsset = Instantiate(spawnerAssetReference);
            }

            else
            {
                Debug.LogError("[FishGame::Main::LoadSpawner -> FishSpawner couldn't be loaded from Resources folder!");
                throw new NullReferenceException();
            }
        }

        private void LoadAssetContainerAsset()
        {
            var assetContainerReference = Resources.Load<FishAssetContainer>(ContainerAssetPath);
            
            if (assetContainerReference != null)
            {
                ContainerAsset = assetContainerReference;
            }

            else
            {
                Debug.LogError("[FishGame::Main::LoadAssetContainer -> FishAssetContainer couldn't be loaded from Resources folder!");
                throw new NullReferenceException();
            }
        }
    }
}