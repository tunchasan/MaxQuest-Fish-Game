using FishGame.Core.Fish;
using FishGame.Gameplay.Managers;
using UnityEngine;

namespace FishGame.Core.FishingRod
{
    public class HookController : MonoBehaviour
    {
        [Header("@References")]
        [SerializeField] private Transform socket;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out FishController fishController) && FishingRod.Instance.Status)
            {
                fishController.OnCatchByHook(socket);
                
                // Increase hunted fish count
                GameManager.Instance.OnReceiveHuntedFish();
            }
        }
    }
}
