using System.Collections.Generic;
using DefaultNamespace;

namespace Serialization
{
    public class ShooterSession
    {
        public int TotalShotCount { get; }
        public List<WeaponShot> Shots { get; }

        public ShooterSession(int totalShotCount, List<WeaponShot> shots)
        {
            TotalShotCount = totalShotCount;
            Shots = shots;
        }
    }
}