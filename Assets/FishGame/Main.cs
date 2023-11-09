using System;
using FishGame.Core.Fish;
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
        public FishAssetContainer ContainerAsset { get; private set; }
        public Camera MainCamera { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
 
        private void Start()
        {
            LoadCamera();
            LoadConfigAsset();
            LoadFishAsset();
            LoadSpawnerAsset();
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
            var assetContainerReference = Resources.Load<Config>("SO/Config");
            
            if (assetContainerReference != null)
            {
                Config = assetContainerReference;
            }

            else
            {
                throw new NullReferenceException("[FishGame::Main::LoadConfigAsset] Config couldn't be loaded from Resources folder!");
            }
        }

        private void LoadFishAsset()
        {
            var assetContainerReference = Resources.Load<Fish>(Config.FishAssetPath);
            
            if (assetContainerReference != null)
            {
                FishAsset = assetContainerReference;
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