using FishGame.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishGame.Gameplay.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("@References")]
        [SerializeField] private Button resetButton;
        [SerializeField] private TextMeshProUGUI attemptCounterText;
        [SerializeField] private TextMeshProUGUI huntedFishCounterText;

        private void Start()
        {
            resetButton.onClick.AddListener(OnClickResetButton);
        }

        public void UpdateAttemptCounterText(int count)
        {
            attemptCounterText.text = $"x{count}";
        }
        
        public void HuntedFishCounterText(int count)
        {
            huntedFishCounterText.text = $"x{count}";
        }

        private void OnClickResetButton()
        {
            LevelManager.Instance.ResetScene();
        }

        private void OnDestroy()
        {
            resetButton.onClick.RemoveListener(OnClickResetButton);
        }
    }
}