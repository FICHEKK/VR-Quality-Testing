namespace VRQualityTesting.Scripts.Shooter
{
    public class TargetHit
    {
        public float DistanceFromTarget { get; }
        public float DistanceFromHitToCenter { get; }
        public int TargetLifeDurationInMs { get; }

        public TargetHit(float distanceFromTarget, float distanceFromHitToCenter, int targetLifeDurationInMs)
        {
            DistanceFromTarget = distanceFromTarget;
            DistanceFromHitToCenter = distanceFromHitToCenter;
            TargetLifeDurationInMs = targetLifeDurationInMs;
        }
    }
}