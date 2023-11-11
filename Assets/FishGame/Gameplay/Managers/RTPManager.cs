using FishGame.Utilities;

namespace FishGame.Gameplay.Managers
{
    public class RTPManager : Singleton<RTPManager>
    {
        private const float Rtp = .3F;
        private const int RtpMultiplier = 30;

        public float FishHauntChanceRate()
        {
            var fishHauntChance = Rtp * (Rtp * RtpMultiplier / Main.Instance.Config.InitialFishCount);
            return fishHauntChance;
        }
    }
}