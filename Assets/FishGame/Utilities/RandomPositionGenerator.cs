using UnityEngine;

namespace FishGame.Utilities
{
    public static class RandomPositionGenerator
    {
        private static readonly Vector2 Margin = new(100, 100);

        public static Vector2 GetRandomPosition()
        {
            var spawnY = Random.Range(
                Main.Instance.MainCamera.ScreenToWorldPoint(new Vector2(0, Margin.y)).y, 
                Main.Instance.MainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height - Margin.y)).y);
            
            var spawnX = Random.Range(
                Main.Instance.MainCamera.ScreenToWorldPoint(new Vector2(Margin.x, 0)).x, 
                Main.Instance.MainCamera.ScreenToWorldPoint(new Vector2(Screen.width - Margin.x, 0)).x);
 
            return new Vector2(spawnX, spawnY);
        }
    }
}