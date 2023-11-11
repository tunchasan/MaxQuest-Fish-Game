using System;
using FishGame.Utilities;

namespace FishGame.Gameplay.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public int AttemptCount { get; private set; }
        public int HuntedFishCount { get; private set; }

        public void OnReceiveAttempt()
        {
            AttemptCount++;
            UIManager.Instance.UpdateAttemptCounterText(AttemptCount);
        }

        public void OnReceiveHuntedFish()
        {
            HuntedFishCount++;
            UIManager.Instance.HuntedFishCounterText(HuntedFishCount);
        }
    }
}