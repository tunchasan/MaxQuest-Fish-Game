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

        public Fish Fish { get; private set; }
        public FishSpawner Spawner { get; private set; }
        public FishAssetContainer AssetContainer { get; private set; }

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
                Fish = assetContainerReference;
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
                Spawner = Instantiate(spawnerAssetReference);
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
                AssetContainer = assetContainerReference;
            }

            else
            {
                Debug.LogError("[FishGame::Main::LoadAssetContainer -> FishAssetContainer couldn't be loaded from Resources folder!");
                throw new NullReferenceException();
            }
        }
    }
}