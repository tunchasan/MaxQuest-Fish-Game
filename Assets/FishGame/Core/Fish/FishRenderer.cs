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
    }
}