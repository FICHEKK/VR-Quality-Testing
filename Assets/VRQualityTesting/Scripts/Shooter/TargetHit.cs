namespace VRQualityTesting.Scripts.Shooter
{
    public class TargetHit
    {
        public float DistanceFromTarget { get; }
        public float DistanceFromHitToCenter { get; }

        public TargetHit(float distanceFromTarget, float distanceFromHitToCenter)
        {
            DistanceFromTarget = distanceFromTarget;
            DistanceFromHitToCenter = distanceFromHitToCenter;
        }
    }
}