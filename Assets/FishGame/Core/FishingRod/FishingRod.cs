using System.Collections;
using UnityEngine;

namespace FishGame.Core.FishingRod
{
    public class FishingRod : MonoBehaviour
    {
        [Header("@References")]
        [SerializeField] private Transform hook;
        [SerializeField] private LineRenderer lineRenderer;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var worldPosition = Main.Instance.MainCamera.ScreenToWorldPoint(
                    new Vector3(
                          Input.mousePosition.x,
                          Input.mousePosition.y,
                        Main.Instance.MainCamera.nearClipPlane));

                hook.gameObject.SetActive(true);
                StartCoroutine(LerpValues(worldPosition.x));
            }
        }
        
        private IEnumerator LerpValues(float positionX)
        {
            var elapsedTime = 0F;
            lineRenderer.positionCount = 1;
            
            while (elapsedTime < 1F)
            {
                var spaceInterval = Mathf.Lerp(0F, -1F, elapsedTime);
                lineRenderer.SetPosition(0, new Vector3(positionX, 6F, -1F));
                
                for (var i = 1; i < 50; i++)
                {
                    if (lineRenderer.positionCount < 50)
                    {
                        lineRenderer.positionCount += 1;
                    }
                    
                    lineRenderer.SetPosition(i, new Vector3(
                        positionX, 
                        Mathf.Lerp(lineRenderer.GetPosition(i - 1).y, lineRenderer.GetPosition(i - 1).y + spaceInterval / Random.Range(5F, 8F), elapsedTime), 
                        -1));
                }

                hook.position = lineRenderer.GetPosition(49);
                elapsedTime += Time.deltaTime * 2F;
                yield return null; // Wait for the next frame
            }
        }
    }
}