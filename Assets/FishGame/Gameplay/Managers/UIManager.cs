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
        [SerializeField] private TextMeshProUGUI rtpInfoText;

        private void Start()
        {
            resetButton.onClick.AddListener(OnClickResetButton);
        }

        public void UpdateAttemptCounterText(int count)
        {
            attemptCounterText.text = $"x{count}";
            UpdateRtpInfoText();
        }
        
        public void HuntedFishCounterText(int count)
        {
            huntedFishCounterText.text = $"x{count}";
            UpdateRtpInfoText();
        }

        private void UpdateRtpInfoText()
        {
            var rate = (float)GameManager.Instance.HuntedFishCount / GameManager.Instance.AttemptCount;
            rtpInfoText.text = $"RTP : {rate:F1}";
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