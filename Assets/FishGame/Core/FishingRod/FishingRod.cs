using System.Collections;
using FishGame.Gameplay.Managers;
using FishGame.Utilities;
using UnityEngine;

namespace FishGame.Core.FishingRod
{
    public class FishingRod : Singleton<FishingRod>
    {
        [Header("@References")]
        [SerializeField] private Transform hook;
        [SerializeField] private LineRenderer lineRenderer;

        public bool Status { get; private set; }
        
        private bool _isThrowable = true;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ThrowFishingRodTo());
            }

            if (_isThrowable)
            {
                FollowCursor();
            }
        }

        private void FollowCursor()
        {
            var currentPosition = transform.position;
            var mouseWorldPos = Main.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var positionX = Mathf.Lerp(currentPosition.x, mouseWorldPos.x, Time.deltaTime * 3F);
            positionX = Mathf.Clamp(positionX, -8F, 8F);
            transform.position = new Vector3(positionX, currentPosition.y, currentPosition.z);
        }

        private IEnumerator ThrowFishingRodTo()
        {
            if(!_isThrowable) yield break;
            _isThrowable = false;

            Status = true;
            var elapsedTime = 0F;
            lineRenderer.positionCount = 1;
            var positionX = transform.position.x;

            while (elapsedTime < 1F)
            {
                var spaceInterval = Mathf.Lerp(0F, -1F, elapsedTime);
                lineRenderer.SetPosition(0, new Vector3(positionX, 5F, -1F));
                
                for (var i = 1; i < 50; i++)
                {
                    if (lineRenderer.positionCount < 50) { lineRenderer.positionCount += 1; }
                    var position = lineRenderer.GetPosition(i - 1);
                    var lerpPosition = Mathf.Lerp(position.y, position.y + spaceInterval / Random.Range(5F, 8F),elapsedTime);
                    lineRenderer.SetPosition(i, new Vector3(positionX, lerpPosition, -1));
                }

                hook.position = lineRenderer.GetPosition(49);
                elapsedTime += Time.deltaTime * 2F;
                yield return null; // Wait for the next frame
            }

            // Increase hook attempt count
            GameManager.Instance.OnReceiveAttempt();
            
            StartCoroutine(PullFishingRod());
        }
        
        private IEnumerator PullFishingRod()
        {
            var elapsedTime = 0F;
            
            while (elapsedTime < .1F)
            {
                for (var i = 1; i < 50; i++)
                {
                    lineRenderer.SetPosition(i, Vector3.Lerp(lineRenderer.GetPosition(i), lineRenderer.GetPosition(0), elapsedTime));
                }

                hook.position = lineRenderer.GetPosition(49);
                elapsedTime += Time.deltaTime / 5F;
                yield return null; // Wait for the next frame
            }

            lineRenderer.positionCount = 0;
            Status = false;
            _isThrowable = true;
        }
    }
}