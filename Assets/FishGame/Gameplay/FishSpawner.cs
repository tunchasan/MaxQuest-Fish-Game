using FishGame.Model;
using FishGame.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishGame.Gameplay
{
    public class FishSpawner : MonoBehaviour
    {
        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            for (var i = 0; i < Main.Instance.Config.InitialFishCount; i++)
            {
                var fishInstance = Instantiate(Main.Instance.FishAsset);
                fishInstance.transform.position = RandomPositionGenerator.GetRandomPosition();
                var fishAssets = Main.Instance.ContainerAsset.FishAssets;
                var fishSize = Random.Range(.25F, .75F);
                
                fishInstance.SetData(new FishModel
                {
                    Name = $"Fish [Id {i}]",
                    Size = fishSize,
                    Speed = fishSize * 3F,
                    Visual = fishAssets[Random.Range(0, fishAssets.Length)]
                });
            }
        }
    }
}