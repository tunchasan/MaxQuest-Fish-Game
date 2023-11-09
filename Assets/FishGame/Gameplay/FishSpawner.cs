using FishGame.Core.Fish;
using UnityEngine;

namespace FishGame.Gameplay
{
    public class FishSpawner : MonoBehaviour
    {
        [Header("@References")]
        [SerializeField] private Transform spawnerParent;
        
        [Header("@Configurations")]
        [SerializeField] private Fish fishPrefabReference;
    }
}