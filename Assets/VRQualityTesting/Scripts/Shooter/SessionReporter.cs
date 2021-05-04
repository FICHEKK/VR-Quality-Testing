using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    public class SessionReporter : MonoBehaviour
    {
        private const string SuccessfulHitTag = "Target";

        private int _totalShotsFired;
        private readonly List<TargetHit> _targetHits = new List<TargetHit>();

        public void OnWeaponShot() => _totalShotsFired++;

        public void OnWeaponHit(RaycastHit hit)
        {
            if (!hit.transform.CompareTag(SuccessfulHitTag)) return;

            var distanceFromTarget = hit.distance;
            var distanceFromHitToCenter = (hit.point - hit.transform.position).magnitude;

            var targetBirthTimestamp = hit.transform.GetComponent<Target>().BirthTimestamp;
            var tookToDestroy = DateTime.Now - targetBirthTimestamp;

            _targetHits.Add(new TargetHit(distanceFromTarget, distanceFromHitToCenter, (int) tookToDestroy.TotalMilliseconds));
        }

        public void OnTimerRunOut() => SessionPublisher.Publish(new Session(_totalShotsFired, _targetHits));
    }
}
