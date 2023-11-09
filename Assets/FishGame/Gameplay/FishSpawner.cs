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

                fishInstance.SetData(new FishModel
                {
                    Name = $"Fish [Id {i}]",
                    Speed = Random.Range(.5F, 1.5F),
                    Size = Random.Range(.6F, .9F),
                    Visual = fishAssets[Random.Range(0, fishAssets.Length)]
                });
            }
        }
    }
}