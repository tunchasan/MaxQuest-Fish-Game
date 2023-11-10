using FishGame.Model;
using UnityEngine;

namespace FishGame.Core.Fish
{
    [RequireComponent(typeof(FishMovement), typeof(FishRenderer))]
    public class FishController : MonoBehaviour
    {
        private FishMovement _movement;
        private FishRenderer _renderer;

        private void Awake()
        {
            _movement = GetComponent<FishMovement>();
            _renderer = GetComponent<FishRenderer>();
        }

        public void ApplyData(FishModel data)
        {
            gameObject.name = data.Name;
            transform.localScale = Vector3.one * data.Size;
            
            _movement.ApplyMovement(data.Speed);
            _renderer.ApplyRenderer(data.Visual);
        }
        
        public void OnCatchByHook(Transform hook)
        {
            _movement.StopMovement();
            _renderer.SetSortingOrder(20);
            
            var currentTransform = transform;
            currentTransform.SetParent(hook);
            currentTransform.localPosition = hook.localPosition;
        }
    }
}