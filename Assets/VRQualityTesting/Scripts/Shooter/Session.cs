using System.Collections.Generic;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Session
    {
        public int TotalShotsFired { get; }
        public List<TargetHit> Hits { get; }

        public Session(int totalShotsFired, List<TargetHit> hits)
        {
            TotalShotsFired = totalShotsFired;
            Hits = hits;
        }
    }
}