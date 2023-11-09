using UnityEngine;

namespace FishGame.Gameplay
{
    [CreateAssetMenu(fileName = "FishAssetContainer", menuName = "MaxQuest/FishAssetContainer", order = 1)]
    public class FishAssetContainer : ScriptableObject
    {
        [field: SerializeField] public Sprite[] FishAssets { get; private set; }
    }
}