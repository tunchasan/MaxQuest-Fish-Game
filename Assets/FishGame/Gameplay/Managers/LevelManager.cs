using FishGame.Utilities;
using UnityEngine.SceneManagement;

namespace FishGame.Gameplay.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}