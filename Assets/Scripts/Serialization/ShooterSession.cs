using System.Collections.Generic;
using DefaultNamespace;

namespace Serialization
{
    public class ShooterSession
    {
        public int DurationInSeconds { get; }
        public int TotalShotCount { get; }
        public List<WeaponShot> Shots { get; }

        public ShooterSession(int durationInSeconds, int totalShotCount, List<WeaponShot> shots)
        {
            DurationInSeconds = durationInSeconds;
            TotalShotCount = totalShotCount;
            Shots = shots;
        }
    }
}