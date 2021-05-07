using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRQualityTesting.Scripts.Shooter
{
    public class SessionReporter : MonoBehaviour
    {
        private const string TargetTag = "Target";

        [SerializeField] private TargetSpawner targetSpawner;
        private int _totalShotsFired;
        private readonly List<TargetHit> _targetHits = new List<TargetHit>();

        public void OnWeaponShot() => _totalShotsFired++;

        public void OnWeaponHit(RaycastHit hit)
        {
            if (!hit.transform.CompareTag(TargetTag)) return;

            var target = hit.transform.GetComponent<Target>();
            AddTargetHit(hit.point, target);
        }

        public void OnProjectileCollision(Collision collision)
        {
            if (!collision.transform.CompareTag(TargetTag)) return;

            var hitPoint = collision.contacts[0].point;
            var target = collision.transform.GetComponent<Target>();

            AddTargetHit(hitPoint, target);
        }

        private void AddTargetHit(Vector3 hitPoint, Target target)
        {
            var targetTransform = target.transform;
            var targetPosition = targetTransform.position;

            _targetHits.Add(new TargetHit(
                distanceFromTarget: targetPosition.magnitude,
                distanceFromHitToCenter: (hitPoint - targetPosition).magnitude,
                targetLifeDurationInMs: (int) (DateTime.Now - target.BirthTimestamp).TotalMilliseconds,
                targetSize: targetTransform.localScale.x,
                targetVelocity: target.Velocity,
                targetOffset: target.Offset
            ));

            targetSpawner.OnTargetHit();
        }

        public void OnTimerRunOut() => SessionPublisher.Publish(new Session(_totalShotsFired, _targetHits));
    }
}
