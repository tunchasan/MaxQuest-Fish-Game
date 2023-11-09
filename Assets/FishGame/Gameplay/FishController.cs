using FishGame.Model;
using UnityEngine;

namespace FishGame
{
    public class FishController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void ApplyData(FishModel data)
        {
            gameObject.name = data.Name;
            spriteRenderer.sprite = data.Visual;
        }
    }
}