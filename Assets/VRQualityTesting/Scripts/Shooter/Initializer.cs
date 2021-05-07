using BNG;
using UnityEngine;
using VRQualityTesting.Scripts.Utility;

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

        private void Awake()
        {
            InitializeWeapon();
            InitializeTimer();
            InitializeTargetSpawner();
        }

        private void InitializeWeapon()
        {
            var weaponType = (WeaponType) Settings.GetInt(SettingsKeys.Shooter.WeaponType);
            pistol.SetActive(weaponType == WeaponType.Pistol);
            rifle.SetActive(weaponType == WeaponType.Rifle);

            var useLaser = Settings.GetBool(SettingsKeys.Shooter.UseLaser);
            pistolLaser.SetActive(useLaser);
            rifleLaser.SetActive(useLaser);

            var showBulletTrajectory = Settings.GetBool(SettingsKeys.Shooter.ShowBulletTrajectory);
            pistolRaycastWeapon.AlwaysFireProjectile = showBulletTrajectory;
            rifleRaycastWeapon.AlwaysFireProjectile = showBulletTrajectory;

            if (!Settings.GetBool(SettingsKeys.Shooter.ShowMuzzleFlash))
            {
                pistolRaycastWeapon.MuzzleFlashObject = new GameObject();
                rifleRaycastWeapon.MuzzleFlashObject = new GameObject();
            }
        }

        private void InitializeTimer()
        {
            timer.TimeLeft = Settings.GetFloat(SettingsKeys.Shooter.RoundDuration);
        }

        private void InitializeTargetSpawner()
        {
            targetSpawner.MinDistance = Settings.GetFloat(SettingsKeys.Shooter.MinDistance);
            targetSpawner.MaxDistance = Settings.GetFloat(SettingsKeys.Shooter.MaxDistance);
            targetSpawner.MinHeight = Settings.GetFloat(SettingsKeys.Shooter.MinHeight);
            targetSpawner.MaxHeight = Settings.GetFloat(SettingsKeys.Shooter.MaxHeight);
            targetSpawner.SpawnAngle = Settings.GetFloat(SettingsKeys.Shooter.SpawnAngle);
            targetSpawner.SpawnCount = Settings.GetInt(SettingsKeys.Shooter.SpawnCount);
            targetSpawner.DurationBetweenSpawns = Settings.GetFloat(SettingsKeys.Shooter.DurationBetweenSpawns);
            targetSpawner.MinSize = Settings.GetFloat(SettingsKeys.Shooter.MinSize);
            targetSpawner.MaxSize = Settings.GetFloat(SettingsKeys.Shooter.MaxSize);

            targetSpawner.MovingProbability = Settings.GetFloat(SettingsKeys.Shooter.MovingProbability);
            targetSpawner.MinVelocity = Settings.GetFloat(SettingsKeys.Shooter.MinVelocity);
            targetSpawner.MaxVelocity = Settings.GetFloat(SettingsKeys.Shooter.MaxVelocity);
            targetSpawner.MinOffset = Settings.GetFloat(SettingsKeys.Shooter.MinOffset);
            targetSpawner.MaxOffset = Settings.GetFloat(SettingsKeys.Shooter.MaxOffset);
        }
    }
}
