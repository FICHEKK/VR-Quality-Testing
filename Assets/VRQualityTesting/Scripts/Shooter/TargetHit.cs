namespace VRQualityTesting.Scripts.Shooter
{
    public class TargetHit
    {
        public float DistanceFromTarget { get; }
        public float DistanceFromHitToCenter { get; }
        public int TargetLifeDurationInMs { get; }
        public float TargetSize { get; }

        public TargetHit(float distanceFromTarget, float distanceFromHitToCenter, int targetLifeDurationInMs, float targetSize)
        {
            DistanceFromTarget = distanceFromTarget;
            DistanceFromHitToCenter = distanceFromHitToCenter;
            TargetLifeDurationInMs = targetLifeDurationInMs;
            TargetSize = targetSize;
        }
    }
}