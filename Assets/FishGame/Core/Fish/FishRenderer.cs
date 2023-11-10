using UnityEngine;

namespace FishGame.Core.Fish
{
    public class FishRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void ApplyRenderer(Sprite visual)
        {
            spriteRenderer.sprite = visual;
        }

        public void SetFlipX(bool status)
        {
            spriteRenderer.flipX = status;
        }
        
        public void SetFlipY(bool status)
        {
            spriteRenderer.flipY = status;
        }

        public void SetSortingOrder(int order)
        {
            spriteRenderer.sortingOrder = order;
        }
    }
}