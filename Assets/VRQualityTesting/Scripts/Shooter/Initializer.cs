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
            pistol.SetActive(Settings.WeaponType == WeaponType.Pistol);
            rifle.SetActive(Settings.WeaponType == WeaponType.Rifle);

            pistolLaser.SetActive(Settings.UseLaser);
            rifleLaser.SetActive(Settings.UseLaser);

            pistolRaycastWeapon.AlwaysFireProjectile = Settings.ShowBulletTrajectory;
            rifleRaycastWeapon.AlwaysFireProjectile = Settings.ShowBulletTrajectory;

            if (!Settings.ShowMuzzleFlash)
            {
                pistolRaycastWeapon.MuzzleFlashObject = new GameObject();
                rifleRaycastWeapon.MuzzleFlashObject = new GameObject();
            }
        }

        private void InitializeTimer()
        {
            timer.TimeLeft = Settings.RoundDuration;
        }

        private void InitializeTargetSpawner()
        {
            targetSpawner.MinDistance = Settings.MinDistance;
            targetSpawner.MaxDistance = Settings.MaxDistance;
            targetSpawner.MinHeight = Settings.MinHeight;
            targetSpawner.MaxHeight = Settings.MaxHeight;
            targetSpawner.SpawnAngle = Settings.SpawnAngle;
            targetSpawner.SpawnCount = Settings.SpawnCount;
            targetSpawner.DurationBetweenSpawns = Settings.DurationBetweenSpawns;
            targetSpawner.MinTargetSize = Settings.MinTargetSize;
            targetSpawner.MaxTargetSize = Settings.MaxTargetSize;

            targetSpawner.MovingTargetProbability = Settings.MovingTargetProbability;
            targetSpawner.MinVelocity = Settings.MinVelocity;
            targetSpawner.MaxVelocity = Settings.MaxVelocity;
            targetSpawner.MinOffset = Settings.MinOffset;
            targetSpawner.MaxOffset = Settings.MaxOffset;
        }
    }
}
