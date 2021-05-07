namespace VRQualityTesting.Scripts.Shooter
{
    public static class Settings
    {
        public static float MinDistance = 8;
        public static float MaxDistance = 12;
        public static float MinHeight = 2;
        public static float MaxHeight = 6;
        public static float SpawnAngle = 90;
        public static int SpawnCount = 1;
        public static float DurationBetweenSpawns = 1;
        public static float RoundDuration = 30;

        public static float MinTargetSize = 0.5f;
        public static float MaxTargetSize = 2;
        public static float MovingTargetProbability = 0.2f;
        public static float MinVelocity = 0.5f;
        public static float MaxVelocity = 5f;
        public static float MinOffset = 2f;
        public static float MaxOffset = 8f;

        public static WeaponType WeaponType = WeaponType.Pistol;
        public static bool UseLaser = true;
        public static bool ShowBulletTrajectory = false;
        public static bool ShowMuzzleFlash = true;
    }
}
