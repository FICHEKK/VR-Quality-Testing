using UnityEngine;
using VRQualityTesting.Scripts.Core;

namespace VRQualityTesting.Scripts.Shooter
{
    [RequireComponent(typeof(WeaponHandSide))]
    public class WeaponEventReporter : MonoBehaviour
    {
        [SerializeField] private WeaponStatisticsTracker weaponStatisticsTracker;

        public void ReportShot()
        {
            var handSide = GetComponent<WeaponHandSide>().HandSide;
            weaponStatisticsTracker.HandleBulletShot(handSide);
        }

        public void ReportHit(RaycastHit hit)
        {
            var handSide = GetComponent<WeaponHandSide>().HandSide;
            weaponStatisticsTracker.HandleBulletHit(hit, handSide);
        }
    }
}
