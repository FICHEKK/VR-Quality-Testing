using BNG;
using UnityEngine;
using VRQualityTesting.Scripts.Utility;
using VRQualityTesting.Scripts.ShooterMenu;

namespace VRQualityTesting.Scripts.Shooter
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private TargetSpawner targetSpawner;

        [Header("Pistol")]
        [SerializeField] private GameObject pistol;
        [SerializeField] private GameObject pistolLaser;
        [SerializeField] private RaycastWeapon pistolRaycastWeapon;

        [Header("Rifle")]
        [SerializeField] private GameObject rifle;
        [SerializeField] private GameObject rifleLaser;
        [SerializeField] private RaycastWeapon rifleRaycastWeapon;

        [Header("Bullet")]
        [SerializeField] private TrailRenderer bulletTrailRenderer;

        private void Awake()
        {
            InitializeWeapon();
            InitializeTimer();
            InitializeTargetSpawner();
        }

        private void InitializeWeapon()
        {
            var weaponType = (WeaponType) Settings.GetInt(ShooterKeys.WeaponType);
            pistol.SetActive(weaponType == WeaponType.Pistol);
            rifle.SetActive(weaponType == WeaponType.Rifle);

            var useLaser = Settings.GetBool(ShooterKeys.UseLaser);
            pistolLaser.SetActive(useLaser);
            rifleLaser.SetActive(useLaser);

            var showBulletTrajectory = Settings.GetBool(ShooterKeys.ShowBulletTrajectory);
            pistolRaycastWeapon.AlwaysFireProjectile = showBulletTrajectory;
            rifleRaycastWeapon.AlwaysFireProjectile = showBulletTrajectory;

            if (!Settings.GetBool(ShooterKeys.ShowMuzzleFlash))
            {
                pistolRaycastWeapon.MuzzleFlashObject = new GameObject();
                rifleRaycastWeapon.MuzzleFlashObject = new GameObject();
            }

            bulletTrailRenderer.time = Settings.GetFloat(ShooterKeys.BulletTrajectoryTime);
        }

        private void InitializeTimer()
        {
            timer.TimeLeft = Settings.GetFloat(ShooterKeys.RoundDuration);
        }

        private void InitializeTargetSpawner()
        {
            targetSpawner.MinDistance = Settings.GetFloat(ShooterKeys.MinDistance);
            targetSpawner.MaxDistance = Settings.GetFloat(ShooterKeys.MaxDistance);
            targetSpawner.MinHeight = Settings.GetFloat(ShooterKeys.MinHeight);
            targetSpawner.MaxHeight = Settings.GetFloat(ShooterKeys.MaxHeight);
            targetSpawner.SpawnAngle = Settings.GetFloat(ShooterKeys.SpawnAngle);
            targetSpawner.SpawnCount = Settings.GetInt(ShooterKeys.SpawnCount);
            targetSpawner.DurationBetweenSpawns = Settings.GetFloat(ShooterKeys.DurationBetweenSpawns);
            targetSpawner.MinSize = Settings.GetFloat(ShooterKeys.MinSize);
            targetSpawner.MaxSize = Settings.GetFloat(ShooterKeys.MaxSize);

            targetSpawner.MovingProbability = Settings.GetFloat(ShooterKeys.MovingProbability);
            targetSpawner.MinVelocity = Settings.GetFloat(ShooterKeys.MinVelocity);
            targetSpawner.MaxVelocity = Settings.GetFloat(ShooterKeys.MaxVelocity);
            targetSpawner.MinOffset = Settings.GetFloat(ShooterKeys.MinOffset);
            targetSpawner.MaxOffset = Settings.GetFloat(ShooterKeys.MaxOffset);
        }
    }
}
