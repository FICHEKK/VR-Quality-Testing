namespace DefaultNamespace
{
    public class WeaponShot
    {
        public float DistanceFromTarget { get; }
        public float DistanceFromHitToCenter { get; }

        public WeaponShot(float distanceFromTarget, float distanceFromHitToCenter)
        {
            DistanceFromTarget = distanceFromTarget;
            DistanceFromHitToCenter = distanceFromHitToCenter;
        }
    }
}