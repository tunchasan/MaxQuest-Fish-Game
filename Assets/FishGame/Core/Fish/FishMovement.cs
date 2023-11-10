using FishGame.Utilities;
using UnityEngine;

namespace FishGame.Core.Fish
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FishMovement : MonoBehaviour
    {
        private Vector2 _direction;
        private Vector2 _targetPosition;
        private float _movementSpeed;
        private bool _shouldMove = true;

        private Rigidbody2D _physic;
        private FishRenderer _renderer;

        private void Awake()
        {
            _physic = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<FishRenderer>();
        }

        private void Start()
        {
            UpdateDirection();
        }

        private void FixedUpdate()
        {
            if (!_shouldMove)
            {
                _physic.velocity = Vector2.zero;
                return;
            }
            
            ProcessMovement();
            ProcessRotation();
            ProcessDirection();

            if (Vector2.Distance(transform.position, _targetPosition) < 2F)
            {
                UpdateDirection();
            }
        }
        
        public void StopMovement()
        {
            _shouldMove = false;
        }

        private void ProcessMovement()
        {
            var velocity = Vector2.Lerp(_physic.velocity, _direction * _movementSpeed, Time.fixedDeltaTime);
            _physic.velocity = velocity;
        }

        private void ProcessRotation()
        {
            var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime);
        }

        private void ProcessDirection()
        {
            if (_direction.x >= 0F)
            {
                _renderer.SetFlipX(true);
                _renderer.SetFlipY(false);
            }

            else
            {
                _renderer.SetFlipX(true);
                _renderer.SetFlipY(true);
            }
        }

        public void ApplyMovement(float speed)
        {
            _movementSpeed = speed;
        }

        private void UpdateDirection()
        {
            var position = transform.position;
            _targetPosition = RandomPositionGenerator.GetRandomPosition();
            _direction = (_targetPosition - (Vector2)position).normalized;
        }
    }
}