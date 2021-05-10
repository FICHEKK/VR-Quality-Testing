using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    [RequireComponent(typeof(WeaponHandSide))]
    public class WeaponEventReporter : MonoBehaviour
    {
        [SerializeField] private WeaponStatisticsTracker weaponStatisticsTracker;

        public void ReportShot()
        {
            weaponStatisticsTracker.HandleBulletShot();
        }

        public void ReportHit(RaycastHit hit)
        {
            weaponStatisticsTracker.HandleBulletHit(hit, GetComponent<WeaponHandSide>().HandSide);
        }
    }
}