namespace VRQualityTesting.Scripts.Shooter
{
    public class TargetHit
    {
        public float DistanceFromTarget { get; }
        public float DistanceFromHitToCenter { get; }
        public int TargetLifeDurationInMs { get; }
        public float TargetSize { get; }
        public float TargetVelocity { get; }
        public float TargetOffset { get; }
        public string HandSide { get; }

        public TargetHit(
            float distanceFromTarget,
            float distanceFromHitToCenter,
            int targetLifeDurationInMs,
            float targetSize,
            float targetVelocity,
            float targetOffset,
            string handSide)
        {
            DistanceFromTarget = distanceFromTarget;
            DistanceFromHitToCenter = distanceFromHitToCenter;
            TargetLifeDurationInMs = targetLifeDurationInMs;
            TargetSize = targetSize;
            TargetVelocity = targetVelocity;
            TargetOffset = targetOffset;
            HandSide = handSide;
        }
    }
}