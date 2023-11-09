using FishGame.Model;
using UnityEngine;

namespace FishGame.Core.Fish
{
    [RequireComponent(typeof(FishMovement), typeof(FishRenderer))]
    public class FishController : MonoBehaviour
    {
        [SerializeField] private FishMovement movement;
        [SerializeField] private new FishRenderer renderer;

        public void ApplyData(FishModel data)
        {
            gameObject.name = data.Name;
            movement.ApplyMovement(data.Speed);
            renderer.ApplyRenderer(data.Visual);
        }
    }
}