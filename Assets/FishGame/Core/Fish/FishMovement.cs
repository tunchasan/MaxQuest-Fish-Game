using UnityEngine;

namespace FishGame.Core.Fish
{
    public class FishMovement : MonoBehaviour
    {
        private float _movementSpeed;

        public void ApplyMovement(float speed)
        {
            _movementSpeed = speed;
        }
    }
}