using System;
using System.Collections.Generic;
using UnityEngine;
using VRQualityTesting.Scripts.Core;

namespace VRQualityTesting.Scripts.Shooter
{
    public class WeaponStatisticsTracker : MonoBehaviour
    {
        private const string TargetTag = "Target";
        [SerializeField] private TargetSpawner targetSpawner;

        private int _totalShotsFired;
        private readonly List<TargetHit> _targetHits = new List<TargetHit>();

        public void HandleBulletShot() => _totalShotsFired++;

        public void HandleBulletHit(RaycastHit hit, HandSide handSide)
        {
            if (!hit.transform.CompareTag(TargetTag)) return;

            var target = hit.transform.GetComponent<Target>();
            LogTargetHit(hit.point, target, handSide);
        }

        public void HandleBulletCollision(Collision collision, HandSide handSide)
        {
            if (!collision.transform.CompareTag(TargetTag)) return;

            var hitPoint = collision.contacts[0].point;
            var target = collision.transform.GetComponent<Target>();

            LogTargetHit(hitPoint, target, handSide);
        }

        private void LogTargetHit(Vector3 hitPoint, Target target, HandSide handSide)
        {
            var targetTransform = target.transform;
            var targetPosition = targetTransform.position;
            var deathTimestamp = DateTime.Now;

            _targetHits.Add(new TargetHit(
                distanceFromTarget: targetPosition.magnitude,
                distanceFromHitToCenter: (hitPoint - targetPosition).magnitude,
                targetLifeDurationInMs: (int) (deathTimestamp - target.BirthTimestamp).TotalMilliseconds,
                targetSize: targetTransform.localScale.x,
                targetVelocity: target.Velocity,
                targetOffset: target.Offset,
                handSide: handSide,
                birthTimestamp: target.BirthTimestamp,
                deathTimestamp: deathTimestamp
            ));

            targetSpawner.OnTargetHit();
        }

        public void PublishStatistics() => SessionPublisher.Publish(new Session(_totalShotsFired, _targetHits));
    }
}