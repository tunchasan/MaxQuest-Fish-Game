using UnityEngine;

namespace FishGame
{
    [CreateAssetMenu(fileName = "Config", menuName = "MaxQuest/Config", order = 1)]
    public class Config : ScriptableObject
    {
        [field: SerializeField] public int InitialFishCount { get; private set; } = 100;
        [field: SerializeField] public string FishAssetPath { get; private set; } = "Prefabs/Fish";
        [field: SerializeField] public string ManagersAssetPath { get; private set; } = "Prefabs/Managers";
        [field: SerializeField] public string SpawnerAssetPath { get; private set; } = "Prefabs/FishSpawner";
        [field: SerializeField] public string FishingRodAssetPath { get; private set; } = "Prefabs/FishingRod";
        [field: SerializeField] public string ContainerAssetPath { get; private set; } = "SO/FishAssetContainer";
    }
}