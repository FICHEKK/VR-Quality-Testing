using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    public class SessionReporter : MonoBehaviour
    {
        private const string TargetTag = "Target";

        private int _totalShotsFired;
        private readonly List<TargetHit> _targetHits = new List<TargetHit>();

        public void OnWeaponShot() => _totalShotsFired++;

        public void OnWeaponHit(RaycastHit hit)
        {
            if (!hit.transform.CompareTag(TargetTag)) return;

            var target = hit.transform.GetComponent<Target>();
            AddTargetHit(hit.point, target.transform.position, target);
        }

        public void OnProjectileCollision(Collision collision)
        {
            if (!collision.transform.CompareTag(TargetTag)) return;

            var hitPoint = collision.contacts[0].point;
            var targetTransform = collision.transform;
            var targetPosition = targetTransform.position;
            var target = targetTransform.GetComponent<Target>();

            AddTargetHit(hitPoint, targetPosition, target);
        }

        private void AddTargetHit(Vector3 hitPoint, Vector3 targetPosition, Target target) => _targetHits.Add(new TargetHit(
            distanceFromTarget: targetPosition.magnitude,
            distanceFromHitToCenter: (hitPoint - targetPosition).magnitude,
            targetLifeDurationInMs: (int) (DateTime.Now - target.BirthTimestamp).TotalMilliseconds,
            targetSize: target.transform.localScale.x,
            targetVelocity: target.Velocity,
            targetOffset: target.Offset
        ));

        public void OnTimerRunOut() => SessionPublisher.Publish(new Session(_totalShotsFired, _targetHits));
    }
}
