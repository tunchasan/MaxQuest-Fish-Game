using System;
using FishGame.Core.Fish;
using FishGame.Core.FishingRod;
using FishGame.Gameplay;
using FishGame.Utilities;
using UnityEngine;

namespace FishGame
{
    public class Main : Singleton<Main>
    {
        public Config Config { get; private set; }
        public Fish FishAsset { get; private set; }
        public FishSpawner SpawnerAsset { get; private set; }
        public FishingRod FishingRodAsset { get; private set; }
        public FishAssetContainer ContainerAsset { get; private set; }
        public Camera MainCamera { get; private set; }

        private void Start()
        {
            LoadCamera();
            LoadConfigAsset();
            LoadFishAsset();
            LoadSpawnerAsset();
            LoadFishingRodAsset();
            LoadAssetContainerAsset();
        }

        private void LoadCamera()
        {
            MainCamera = FindObjectOfType<Camera>();
            
            if (MainCamera == null)
            {
                throw new NullReferenceException("[FishGame::Main::LoadCamera] Camera couldn't be loaded!");
            }
        }

        private void LoadConfigAsset()
        {
            var configAssetReference = Resources.Load<Config>("SO/Config");
            
            if (configAssetReference != null)
            {
                Config = configAssetReference;
            }

            else
            {
                throw new NullReferenceException("[FishGame::Main::LoadConfigAsset] Config couldn't be loaded from Resources folder!");
            }
        }

        private void LoadFishAsset()
        {
            var fishAssetReference = Resources.Load<Fish>(Config.FishAssetPath);
            
            if (fishAssetReference != null)
            {
                FishAsset = fishAssetReference;
            }

            else
            {
                throw new NullReferenceException("[FishGame::Main::LoadFishAsset] Fish couldn't be loaded from Resources folder!");
            }
        }

        private void LoadSpawnerAsset()
        {
            var spawnerAssetReference = Resources.Load<FishSpawner>(Config.SpawnerAssetPath);

            if (spawnerAssetReference != null)
            {
                SpawnerAsset = Instantiate(spawnerAssetReference);
            }

            else
            {
                throw new NullReferenceException("[FishGame::Main::LoadSpawner] FishSpawner couldn't be loaded from Resources folder!");
            }
        }
        
        private void LoadFishingRodAsset()
        {
            var fishingRodAssetReference = Resources.Load<FishingRod>(Config.FishingRodAssetPath);
            
            if (fishingRodAssetReference != null)
            {
                FishingRodAsset = Instantiate(fishingRodAssetReference);;
            }

            else
            {
                throw new NullReferenceException("[FishGame::Main::LoadFishingRodAsset] FishingRod couldn't be loaded from Resources folder!");
            }
        }

        private void LoadAssetContainerAsset()
        {
            var assetContainerReference = Resources.Load<FishAssetContainer>(Config.ContainerAssetPath);
            
            if (assetContainerReference != null)
            {
                ContainerAsset = assetContainerReference;
            }

            else
            {
                throw new NullReferenceException("[FishGame::Main::LoadAssetContainer] FishAssetContainer couldn't be loaded from Resources folder!");
            }
        }
    }
}